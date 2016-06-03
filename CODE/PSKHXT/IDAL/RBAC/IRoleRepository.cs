using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.RBAC
{
    /// <summary>
    /// 仓储操作层接口——角色信息
    /// </summary>
    public interface IRoleRepository : IRepositoryBase<Role, Int32>
    {
    }
}
