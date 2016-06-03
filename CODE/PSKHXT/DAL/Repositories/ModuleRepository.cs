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
    /// 仓储操作层实现——模块
    /// </summary>
    public class ModuleRepository : RepositoryBase<Module, Int32>, IModuleRepository
    {
        public ModuleRepository(IUnitOfWork unitOfWork)
            : base()
        { }

        public IList<ModuleVM> GetModuleVMList(Expression<Func<Module, bool>> predicate, int limit, int offset, out int total)
        {
            var query = from m1 in base.DbContext.Modules.Where(predicate)
                        join m2 in base.DbContext.Modules on m1.ParentId equals m2.Id into joinModule
                        from item in joinModule.DefaultIfEmpty()
                        select new ModuleVM
                        {
                            Id = m1.Id,
                            Name = m1.Name,
                            LinkUrl = m1.LinkUrl,
                            IsMenu = m1.IsMenu,
                            Code = m1.Code,
                            Description = m1.Description,
                            Enabled = m1.Enabled,
                            ParentId = m1.ParentId,
                            ParentName = item.Name,
                            UpdateDate = m1.UpdateDate
                        };
            total = query.Count();
            if (offset >= 0)
            {
                return query.OrderBy(m => m.Code).Skip(offset).Take(limit).ToList();
            }
            return query.ToList();
        }
    }
}
