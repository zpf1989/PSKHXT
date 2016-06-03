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
using ViewModel;
using ViewModel.RBAC;

namespace BLL.RBAC
{
    public class RoleService : ServiceBase, IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly IModuleService _ModuleService;
        private readonly IPermissionService _PermissionService;

        public RoleService(IRoleRepository roleRepository, IModuleService moduleService, IPermissionService permissionService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._RoleRepository = roleRepository;
            this._ModuleService = moduleService;
            this._PermissionService = permissionService;
        }

        public IQueryable<Role> Roles
        {
            get
            {
                return this._RoleRepository.Entities;
            }
        }

        public OperationResult Insert(RoleVM roleVM)
        {
            try
            {
                Role oldRole = _RoleRepository.Entities.FirstOrDefault(c => c.RoleName == roleVM.RoleName.Trim());
                if (oldRole != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的角色！");
                }
                var entity = new Role
                {
                    RoleName = roleVM.RoleName.Trim(),
                    Description = roleVM.Description,
                    OrderSort = roleVM.OrderSort,
                    Enabled = roleVM.Enabled,
                    UpdateDate = DateTime.Now
                };
                _RoleRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增角色成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增角色失败！" + ex.Message);
            }
        }

        public OperationResult Update(RoleVM roleVM)
        {
            try
            {
                var oldRole = Roles.FirstOrDefault(c => c.Id == roleVM.Id);
                if (oldRole == null)
                {
                    return new OperationResult(OperationResultType.Error, "该角色在数据库中不存在！");
                }
                var other = Roles.FirstOrDefault(c => c.Id != roleVM.Id && c.RoleName == roleVM.RoleName.Trim());
                if (other != null)
                {
                    return new OperationResult(OperationResultType.Warning, "数据库中已经存在相同名称的角色！");
                }
                oldRole.RoleName = roleVM.RoleName.Trim();
                oldRole.Description = roleVM.Description;
                oldRole.OrderSort = roleVM.OrderSort;
                oldRole.Enabled = roleVM.Enabled;
                oldRole.UpdateDate = DateTime.Now;
                _RoleRepository.Update(new Role[] { oldRole });
                return new OperationResult(OperationResultType.Success, "更新角色成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "更新角色失败！" + ex.Message);
            }
        }

        public OperationResult Delete(IEnumerable<RoleVM> list)
        {
            try
            {
                if (list == null || list.Count() < 1)
                {
                    return new OperationResult(OperationResultType.ParamError, "参数错误，请选择需要删除的数据！");
                }

                var roleIds = list.Select(c => c.Id).ToList();
                int count = _RoleRepository.Delete(r => roleIds.Contains(r.Id));
                if (count > 0)
                {
                    return new OperationResult(OperationResultType.Success, "删除角色成功！");
                }
                else
                {
                    return new OperationResult(OperationResultType.Error, "删除角色失败！");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "删除角色失败！" + ex.Message);
            }
        }

        public IList<ZTreeVM> GetZTreeVMList(int id)
        {
            List<ZTreeVM> result = new List<ZTreeVM>();
            List<double> permissionIds = Roles.First(r => r.Id == id).Permissions.Select(p => p.Id + 0.5).ToList();
            List<ZTreeVM> moduleNodes = _ModuleService.Modules.Where(m => m.Enabled).OrderBy(m => m.Code).Select(
                m => new ZTreeVM()
                {
                    id = m.Id,
                    pId = m.ParentId,
                    name = m.Name,
                    isRoot = !m.ParentId.HasValue,
                    open = !m.ParentId.HasValue
                }
                ).ToList();
            List<ZTreeVM> permissionNodes = this._PermissionService.Permissions
                .Where(p => p.Enabled)
                .Select(
                p => new ZTreeVM()
                {
                    id = p.Id + 0.5,
                    pId = p.ModuleId,
                    name = p.Name
                }).ToList();
            foreach (var node in permissionNodes)
            {
                if (permissionIds.Contains(node.id))
                {
                    node.@checked = true;
                }
            }
            result.AddRange(moduleNodes);
            result.AddRange(permissionNodes);
            return result;
        }

        public OperationResult UpdateAuthorize(int roleId, int[] permissionIds)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var oldRole = Roles.FirstOrDefault(r => r.Id == roleId);
                    if (oldRole == null)
                    {
                        return new OperationResult(OperationResultType.Error, "更新角色权限失败，角色不存在！");
                    }
                    oldRole.Permissions.Clear();
                    var permissions = _PermissionService.Permissions.Where(p => permissionIds.Contains(p.Id)).ToList();
                    oldRole.Permissions = permissions;
                    UnitOfWork.Commit();
                    scope.Complete();
                    return new OperationResult(OperationResultType.Success, "更新角色权限成功！");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Success, "更新角色权限失败！" + ex.Message);
            }
        }
    }
}
