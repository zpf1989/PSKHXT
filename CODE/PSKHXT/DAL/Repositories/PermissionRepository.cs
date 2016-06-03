using IDAL;
using IDAL.RBAC;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace DAL.Repositories
{
    /// <summary>
    /// 仓储操作层实现——权限
    /// </summary>
    public class PermissionRepository : RepositoryBase<Permission, Int32>, IPermissionRepository
    {
        public PermissionRepository(IUnitOfWork unitOfWork)
            : base()
        { }
        public IList<PermissionVM> GetPermissionVMList(Expression<Func<Permission, bool>> predicate, int limit, int offset, out int total)
        {
            var query = from p in base.DbContext.Permissions.Where(predicate)
                        join m in base.DbContext.Modules on p.Module.Id equals m.Id into joinModule
                        from item in joinModule
                        select new PermissionVM
                        {
                            Id = p.Id,
                            Code = p.Code,
                            Name = p.Name,
                            Description = p.Description,
                            Enabled = p.Enabled,
                            UpdateDate = p.UpdateDate,
                            ModuleId = item.Id,
                            ModuleName = item.Name
                        };
            total = query.Count();
            if (offset >= 0)
            {
                return query.OrderBy(p => p.ModuleId).ThenBy(p => p.Code).Skip(offset).Take(limit).ToList();
            }
            return query.ToList();
        }
    }
}
