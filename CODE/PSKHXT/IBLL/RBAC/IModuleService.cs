using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace IBLL.RBAC
{
    /// <summary>
    /// 系统模块信息业务接口
    /// </summary>
    public interface IModuleService
    {
        IQueryable<Module> Modules { get; }

        /// <summary>
        /// 贪婪加载Module实体数据集
        /// </summary>
        /// <param name="inclueList"></param>
        /// <returns></returns>
        IQueryable<Module> GetEntitiesByEager(IEnumerable<string> inclueList);

        /// <summary>
        /// 获取模块分页列表
        /// </summary>
        /// <param name="wh"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        IList<ModuleVM> GetModuleVMList(Expression<Func<Module, bool>> wh, int limit, int offset, out int total);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="moduleVM"></param>
        /// <returns></returns>
        OperationResult Insert(ModuleVM moduleVM);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moduleVM"></param>
        /// <returns></returns>
        OperationResult Update(ModuleVM moduleVM);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        OperationResult Delete(IEnumerable<ModuleVM> list);
    }
}
