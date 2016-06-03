using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.RBAC;

namespace IBLL.RBAC
{
    /// <summary>
    /// 角色信息业务接口
    /// </summary>
    public interface IRoleService
    {
        IQueryable<Role> Roles { get; }
        OperationResult Insert(RoleVM roleVM);
        OperationResult Update(RoleVM roleVM);
        OperationResult Delete(IEnumerable<RoleVM> list);
        IList<ZTreeVM> GetZTreeVMList(int id);
        OperationResult UpdateAuthorize(int roleId, int[] permissionIds);
    }
}
