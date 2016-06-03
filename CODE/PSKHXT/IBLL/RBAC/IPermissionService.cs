using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace IBLL.RBAC
{
    /// <summary>
    /// 授权信息业务接口
    /// </summary>
    public interface IPermissionService
    {
        IQueryable<Permission> Permissions { get; }

        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <param name="wh"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        IList<PermissionVM> GetPermissionVMList(Expression<Func<Permission, bool>> wh, int limit, int offset, out int total);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="permissionVM"></param>
        /// <returns></returns>
        OperationResult Insert(PermissionVM permissionVM);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="permissionVM"></param>
        /// <returns></returns>
        OperationResult Update(PermissionVM permissionVM);
    }
}
