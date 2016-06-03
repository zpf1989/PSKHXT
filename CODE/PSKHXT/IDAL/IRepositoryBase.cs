﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 仓储接口层——base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepositoryBase<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        #region 公共方法
        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        TEntity GetByKey(TKey key);
        /// <summary>
        /// (贪婪加载)返回指定实体数据集
        /// </summary>
        /// <param name="includeList">贪婪加载属性集合</param>
        /// <returns>指定实体数据集</returns>
        IQueryable<TEntity> GetEntitiesByEager(IEnumerable<string> includeList);
        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(TEntity entity, bool isSave = true);

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(IEnumerable<TEntity> entities, bool isSave = true);

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(TKey id, bool isSave = true);

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(TEntity entity, bool isSave = true);

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(IEnumerable<TEntity> entities, bool isSave = true);

        /// <summary>
        ///  （扩展）删除所有符合特定表达式的数据（EntityFramework.Extensions扩展）,用法详见https://github.com/loresoft/EntityFramework.Extended
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true);

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entities"> 实体对象集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Update(IEnumerable<TEntity> entities, bool isSave = true);

        /// <summary>
        /// 修改所有符合特定表达式的数据（EntityFramework.Extensions扩展））,用法详见https://github.com/loresoft/EntityFramework.Extended
        /// </summary>
        /// <param name="filter">过滤查询</param>
        /// <param name="updateExpression">更新表达式</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>返回影响的行数</returns>
        int Update(IQueryable<TEntity> filter, Expression<Func<TEntity, TEntity>> updateExpression, bool isSave = true);

        #endregion
    }
}
