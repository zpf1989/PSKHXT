using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace IDAL.RBAC
{
    /// <summary>
    /// 仓储操作层接口——权限
    /// </summary>
    public interface IPermissionRepository : IRepositoryBase<Permission, Int32>
    {
        IList<PermissionVM> GetPermissionVMList(Expression<Func<Permission, bool>> predicate, int limit, int offset, out int total);
    }
}
