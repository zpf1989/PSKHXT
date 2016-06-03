using IBLL.RBAC;
using IDAL;
using IDAL.RBAC;
using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ViewModel.RBAC;

namespace BLL.RBAC
{
    public class UserGroupService : ServiceBase, IUserGroupService
    {
        private readonly IUserGroupRepository _UserGroupRepository;
        private readonly IRoleService _RoleService;

        public UserGroupService(IUserGroupRepository userGroupRepository, IRoleService roleService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._UserGroupRepository = userGroupRepository;
            this._RoleService = roleService;
        }

        public IQueryable<UserGroup> UserGroups
        {
            get
            {
                return this._UserGroupRepository.Entities;
            }
        }

        public OperationResult Insert(UserGroupVM userGroupVM)
        {
            try
            {
                UserGroup oldGroup = _UserGroupRepository.Entities.FirstOrDefault(c => c.GroupName == userGroupVM.GroupName.Trim());
                if (oldGroup != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的用户组！");
                }
                var entity = new UserGroup()
                {
                    GroupName = userGroupVM.GroupName.Trim(),
                    Description = userGroupVM.Description,
                    OrderSort = userGroupVM.OrderSort,
                    Enabled = userGroupVM.Enabled,
                    UpdateDate = DateTime.Now
                };
                _UserGroupRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增用户组成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增用户组失败！" + ex.Message);
            }
        }

        public OperationResult Update(UserGroupVM userGroupVM)
        {
            try
            {
                var oldUserGroup = UserGroups.FirstOrDefault(c => c.Id == userGroupVM.Id);
                if (oldUserGroup == null)
                {
                    return new OperationResult(OperationResultType.Error, "该用户组在数据库中不存在！");
                }
                var other = UserGroups.FirstOrDefault(c => c.Id != userGroupVM.Id && c.GroupName == userGroupVM.GroupName.Trim());
                if (other != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的用户组！");
                }
                oldUserGroup.GroupName = userGroupVM.GroupName.Trim();
                oldUserGroup.Description = userGroupVM.Description;
                oldUserGroup.OrderSort = userGroupVM.OrderSort;
                oldUserGroup.Enabled = userGroupVM.Enabled;
                oldUserGroup.UpdateDate = DateTime.Now;
                _UserGroupRepository.Update(new UserGroup[] { oldUserGroup });
                return new OperationResult(OperationResultType.Success, "更新用户组成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "更新用户组失败！" + ex.Message);
            }
        }

        public OperationResult Delete(IEnumerable<UserGroupVM> list)
        {
            try
            {
                if (list == null || list.Count() < 1)
                {
                    return new OperationResult(OperationResultType.ParamError, "删除用户组失败，请选择要删除的用户组");
                }
                var usrGroupIds = list.Select(g => g.Id).ToList();
                int rst = this._UserGroupRepository.Delete(g => usrGroupIds.Contains(g.Id));
                if (rst > 0)
                {
                    return new OperationResult(OperationResultType.Success, "删除用户组成功！");
                }
                else
                {
                    return new OperationResult(OperationResultType.Error, "删除用户组失败！");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "删除用户组失败！" + ex.Message);
            }
        }

        public OperationResult UpdateUserGroupRoles(int userGroupId, string[] chkRoleIds)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var oldUserGroup = this._UserGroupRepository.Entities.First(g => g.Id == userGroupId);
                    if (oldUserGroup == null)
                    {
                        return new OperationResult(OperationResultType.ParamError, "设置用户组角色失败，请选择要设置的用户组");
                    }
                    oldUserGroup.Roles.Clear();
                    if (chkRoleIds != null && chkRoleIds.Length > 0)
                    {
                        int[] intRoleIds = Array.ConvertAll<string, int>(chkRoleIds, Convert.ToInt32);
                        List<Role> newRoles = this._RoleService.Roles.Where(r => intRoleIds.Contains(r.Id)).ToList();
                        oldUserGroup.Roles = newRoles;
                    }
                    base.UnitOfWork.Commit();
                    scope.Complete();
                    return new OperationResult(OperationResultType.Success, "设置用户组角色成功！");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "设置用户组角色失败！" + ex.Message);
            }
        }
    }
}
