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
    /// 仓储操作层实现——用户组信息
    /// </summary>
    public class UserGroupRepository : RepositoryBase<UserGroup, Int32>, IUserGroupRepository
    {
        public UserGroupRepository(IUnitOfWork unitOfWork)
            : base()
        { }
    }
}
