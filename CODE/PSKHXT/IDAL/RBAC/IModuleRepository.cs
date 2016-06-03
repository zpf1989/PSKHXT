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
    /// 仓储操作层接口——模块
    /// </summary>
    public interface IModuleRepository : IRepositoryBase<Module, Int32>
    {
        IList<ModuleVM> GetModuleVMList(Expression<Func<Module, bool>> predicate, int limit, int offset, out int total);
    }
}
