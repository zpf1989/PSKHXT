using IDAL;
using IDAL.RBAC;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    /// <summary>
    /// 仓储操作层实现——角色信息
    /// </summary>
    public class RoleRepository : RepositoryBase<Role, Int32>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
}
