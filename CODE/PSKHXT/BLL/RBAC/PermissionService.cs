using IBLL.RBAC;
using IDAL;
using IDAL.RBAC;
using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace BLL.RBAC
{
    public class PermissionService : ServiceBase, IPermissionService
    {
        private readonly IPermissionRepository _PermissionRepository;

        public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._PermissionRepository = permissionRepository;
        }
        public IQueryable<Permission> Permissions
        {
            get { return this._PermissionRepository.Entities; }
        }
        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <param name="wh">查询where表达式</param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<PermissionVM> GetPermissionVMList(Expression<Func<Permission, bool>> wh, int limit, int offset, out int total)
        {
            return this._PermissionRepository.GetPermissionVMList(wh, limit, offset, out total);
        }

        public OperationResult Insert(PermissionVM permissionVM)
        {
            try
            {
                Permission oldPermission = Permissions.FirstOrDefault(c => (c.Name == permissionVM.Name.Trim() || c.Code == permissionVM.Code.Trim()));
                if (oldPermission != null)
                {
                    return new OperationResult(OperationResultType.Warning, "该模块中已经存在相同名称或编码的权限！");
                }
                var entity = new Permission
                {
                    Code = permissionVM.Code.Trim(),
                    Name = permissionVM.Name.Trim(),
                    ModuleId = permissionVM.ModuleId,
                    Description = permissionVM.Description,
                    Enabled = permissionVM.Enabled,
                    UpdateDate = DateTime.Now
                };
                _PermissionRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增权限成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增权限失败！" + ex.Message);
            }
        }

        public OperationResult Update(PermissionVM permissionVM)
        {
            try
            {
                var permission = Permissions.FirstOrDefault(c => c.Id == permissionVM.Id);
                if (permission == null)
                {
                    return new OperationResult(OperationResultType.Error, "该权限在数据库中不存在！");

                }
                var other = Permissions.FirstOrDefault(c => c.Id != permissionVM.Id && c.ModuleId == permissionVM.ModuleId && (c.Name == permissionVM.Name.Trim() || c.Code == permissionVM.Code.Trim()));
                if (other != null)
                {
                    return new OperationResult(OperationResultType.Warning, "该模块中已经存在相同名称或编码的权限，请修改后重新提交！");
                }
                permission.Name = permissionVM.Name.Trim();
                permission.ModuleId = permissionVM.ModuleId;
                permission.Code = permissionVM.Code.Trim();
                permission.Description = permissionVM.Description;
                permission.Enabled = permissionVM.Enabled;
                permission.UpdateDate = DateTime.Now;
                _PermissionRepository.Update(new Permission[] { permission });
                return new OperationResult(OperationResultType.Success, "更新权限成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "更新权限失败！" + ex.Message);
            }
        }
    }
}
