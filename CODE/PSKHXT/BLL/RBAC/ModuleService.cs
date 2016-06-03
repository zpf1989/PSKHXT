using IBLL.RBAC;
using IDAL;
using IDAL.RBAC;
using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace BLL.RBAC
{
    public class ModuleService : ServiceBase, IModuleService
    {
        private IModuleRepository _ModuleRepository;

        public ModuleService(IModuleRepository moduleRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._ModuleRepository = moduleRepository;
        }

        public IQueryable<Module> Modules
        {
            get
            {
                return this._ModuleRepository.Entities;
            }
        }
        /// <summary>
        /// 贪婪加载实体
        /// </summary>
        /// <param name="inclueList"></param>
        /// <returns></returns>
        public IQueryable<Module> GetEntitiesByEager(IEnumerable<string> inclueList)
        {
            return this._ModuleRepository.GetEntitiesByEager(inclueList);
        }

        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <param name="wh"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<ModuleVM> GetModuleVMList(Expression<Func<Module, bool>> wh, int limit, int offset, out int total)
        {
            return this._ModuleRepository.GetModuleVMList(wh, limit, offset, out total);
        }

        public OperationResult Insert(ModuleVM moduleVM)
        {
            try
            {
                Module module = Modules.FirstOrDefault(m => (m.Code == moduleVM.Code || m.Name == moduleVM.Name.Trim()));
                if (module != null)
                {
                    return new OperationResult(OperationResultType.Warning, "该模块中已经存在相同名称或编码的权限！");
                }
                var entity = new Module
                {
                    Code = moduleVM.Code,
                    Name = moduleVM.Name.Trim(),
                    ParentId = moduleVM.ParentId,
                    LinkUrl = moduleVM.LinkUrl,
                    IsMenu = moduleVM.IsMenu,
                    Description = moduleVM.Description,
                    Enabled = moduleVM.Enabled,
                    UpdateDate = DateTime.Now
                };
                this._ModuleRepository.Insert(entity);
                return new OperationResult(OperationResultType.Success, "新增模块成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "新增模块失败。" + ex.Message);
            }
        }

        public OperationResult Update(ModuleVM moduleVM)
        {
            try
            {
                var module = Modules.FirstOrDefault(c => c.Id == moduleVM.Id);
                if (module == null)
                {
                    return new OperationResult(OperationResultType.Error, "该模块在数据库中不存在！");
                }
                var other = Modules.FirstOrDefault(c => c.Id != moduleVM.Id && (c.Code == moduleVM.Code || c.Name == moduleVM.Name.Trim()));
                if (other != null)
                {
                    return new OperationResult(OperationResultType.Warning, "该模块中已经存在相同名称或编码的权限！");
                }
                module.Code = moduleVM.Code;
                module.Name = moduleVM.Name.Trim();
                module.ParentId = moduleVM.ParentId;
                module.LinkUrl = moduleVM.LinkUrl;
                module.IsMenu = moduleVM.IsMenu;
                module.Description = moduleVM.Description;
                module.Enabled = moduleVM.Enabled;
                module.UpdateDate = DateTime.Now;
                _ModuleRepository.Update(new Module[] { module });
                return new OperationResult(OperationResultType.Success, "更新数据成功！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "更新数据失败！" + ex.Message);
            }
        }

        public OperationResult Delete(IEnumerable<ModuleVM> list)
        {
            try
            {
                if (list == null || list.Count() < 1)
                {
                    return new OperationResult(OperationResultType.ParamError, "参数错误，请选择需要删除的数据!");
                }
                var moduleIds = list.Select(c => c.Id).ToList();
                int count = _ModuleRepository.Delete(m => moduleIds.Contains(m.Id));
                if (count > 0)
                {
                    return new OperationResult(OperationResultType.Success, "删除模块成功！");
                }
                else
                {
                    return new OperationResult(OperationResultType.Error, "删除模块失败!");
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "删除数据失败！" + ex.Message);
            }
        }
    }
}
