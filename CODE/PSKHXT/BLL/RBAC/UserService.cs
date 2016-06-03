using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;
using IBLL.RBAC;
using IDAL;
using IDAL.RBAC;
using Model.RBAC;
using Infrastructure.OptResult;
using Infrastructure;
using System.Transactions;
using System.Web.Caching;

namespace BLL.RBAC
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IRoleService _RoleService;
        private readonly IUserGroupService _UserGroupService;
        private readonly IAccountService _AccountService;

        public UserService(IUserRepository userRepository, IRoleService roleService, IUserGroupService userGroupService, IAccountService accountService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._UserRepository = userRepository;
            this._RoleService = roleService;
            this._UserGroupService = userGroupService;
            this._AccountService = accountService;
        }

        public IQueryable<User> Users
        {
            get { return this._UserRepository.Entities; }
        }

        public OperationResult Insert(UserVM userVM)
        {
            try
            {
                User oldUser = _UserRepository.Entities.FirstOrDefault(c => c.UserName == userVM.UserName.Trim());
                if (oldUser != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同的用户名称！");
                }
                var entity = new User
                {
                    UserName = userVM.UserName.Trim(),
                    TrueName = userVM.TrueName.Trim(),
                    Password = userVM.Password,
                    Phone = userVM.Phone,
                    Email = userVM.Email,
                    Address = userVM.Address,
                    Enabled = userVM.Enabled,
                    UpdateDate = DateTime.Now
                };
                _UserRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增用户成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增用户失败！" + ex.Message);
            }
        }

        public OperationResult Update(UserVM userVM)
        {
            try
            {
                var user = Users.FirstOrDefault(c => c.Id == userVM.Id);
                if (user == null)
                {
                    return new OperationResult(OperationResultType.Error, "该用户在数据库中不存在！");
                }
                var other = Users.FirstOrDefault(c => c.Id != userVM.Id && c.UserName == userVM.UserName.Trim());
                if (other != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同的用户名称！");
                }
                user.TrueName = userVM.TrueName.Trim();
                user.UserName = userVM.UserName.Trim();
                user.Address = userVM.Address;
                user.Phone = userVM.Phone;
                user.Email = userVM.Email;
                user.UpdateDate = DateTime.Now;
                _UserRepository.Update(new User[] { user });
                return new OperationResult(OperationResultType.Success, "更新用户成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "更新用户失败！" + ex.Message);
            }
        }

        public OperationResult Delete(IEnumerable<UserVM> list)
        {
            try
            {
                if (list == null || list.Count() < 1)
                {
                    return new OperationResult(OperationResultType.ParamError, "删除用户失败，请选择要删除的用户");
                }
                var usrIds = list.Select(u => u.Id).ToList();
                int rst = this._UserRepository.Delete(u => usrIds.Contains(u.Id));
                if (rst > 0)
                {
                    return new OperationResult(OperationResultType.Success, "删除用户成功！");
                }
                else
                {
                    return new OperationResult(OperationResultType.Error, "删除用户失败！");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "删除用户失败！" + ex.Message);
            }
        }

        public OperationResult ResetPassword(IEnumerable<UserVM> list)
        {
            if (list == null || list.Count() < 1)
            {
                return new OperationResult(OperationResultType.ParamError, "密码重置失败，没有找到指定用户");
            }
            var listIds = list.Select(u => u.Id).ToList();
            try
            {
                string md5Pwd = EncryptionHelper.GetMd5Hash("123456");
                _UserRepository.Update(this.Users.Where(u => listIds.Contains(u.Id)), u => new User { Password = md5Pwd });
                UnitOfWork.Commit();
                return new OperationResult(OperationResultType.Success, "密码重置成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "密码重置失败！" + ex.Message);
            }
        }

        public OperationResult UpdateUserRoles(int userId, string[] chkRoleIds)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var oldUser = Users.FirstOrDefault(c => c.Id == userId);
                    if (oldUser == null)
                    {
                        return new OperationResult(OperationResultType.ParamError, "设置用户角色失败，未找到用户！");
                    }
                    oldUser.Roles.Clear();
                    List<Role> newRoles = new List<Role>();
                    if (chkRoleIds != null && chkRoleIds.Length > 0)
                    {
                        int[] intRoleIds = Array.ConvertAll<string, int>(chkRoleIds, Convert.ToInt32);
                        newRoles = _RoleService.Roles.Where(c => intRoleIds.Contains(c.Id)).ToList();
                        oldUser.Roles = newRoles;
                    }
                    UnitOfWork.Commit();
                    // 重置权限缓存
                    var roleIdsByUser = newRoles.Select(r => r.Id).ToList();
                    var roleIdsByUserGroup = oldUser.UserGroups.SelectMany(g => g.Roles).Select(r => r.Id).ToList();
                    roleIdsByUser.AddRange(roleIdsByUserGroup);
                    var roleIds = roleIdsByUser.Distinct().ToList();
                    List<Permission> permissions = _RoleService.Roles
                        .Where(t => roleIds.Contains(t.Id) && t.Enabled == true)
                        .SelectMany(c => c.Permissions)
                        .Distinct()
                        .ToList();
                    _AccountService.SetUserPermissionCache(oldUser, permissions);
                    scope.Complete();
                    return new OperationResult(OperationResultType.Success, "设置用户角色成功！");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "设置用户角色失败！" + ex.Message);
            }
        }

        public OperationResult UpdateUserGroups(int userId, string[] chkUserGroupIds)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var oldUser = Users.FirstOrDefault(c => c.Id == userId);
                    if (oldUser == null)
                    {
                        return new OperationResult(OperationResultType.ParamError, "设置用户组失败，未找到用户！");
                    }
                    oldUser.UserGroups.Clear();
                    List<UserGroup> newUserGroups = new List<UserGroup>();
                    if (chkUserGroupIds != null && chkUserGroupIds.Length > 0)
                    {
                        int[] idInts = Array.ConvertAll<string, int>(chkUserGroupIds, Convert.ToInt32);
                        newUserGroups = _UserGroupService.UserGroups.Where(c => idInts.Contains(c.Id)).ToList();
                        oldUser.UserGroups = newUserGroups;
                    }
                    UnitOfWork.Commit();
                    //重置权限缓存
                    var roleIdsByUser = newUserGroups.Select(r => r.Id).ToList();
                    var roleIdsByUserGroup = oldUser.UserGroups.SelectMany(g => g.Roles).Select(r => r.Id).ToList();
                    roleIdsByUser.AddRange(roleIdsByUserGroup);
                    var roleIds = roleIdsByUser.Distinct().ToList();
                    List<Permission> permissions = _RoleService.Roles
                        .Where(t => roleIds.Contains(t.Id) && t.Enabled == true)
                        .SelectMany(c => c.Permissions)
                        .Distinct()
                        .ToList();
                    _AccountService.SetUserPermissionCache(oldUser, permissions);
                    scope.Complete();
                    return new OperationResult(OperationResultType.Success, "设置用户组成功！");
                }
            }
            catch
            {
                return new OperationResult(OperationResultType.Error, "设置用户组失败!");
            }
        }
    }
}
