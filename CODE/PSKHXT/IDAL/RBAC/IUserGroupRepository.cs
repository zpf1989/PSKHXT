using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.RBAC
{
    /// <summary>
    /// 仓储操作层接口——用户组
    /// </summary>
    public interface IUserGroupRepository : IRepositoryBase<UserGroup, Int32>
    {
    }
}
