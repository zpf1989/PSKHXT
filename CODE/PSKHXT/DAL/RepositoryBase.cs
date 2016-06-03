using IDAL;
using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    /// <summary>
    /// 仓储层基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        /// <summary>
        /// 获取仓储上下文的实例(线程内唯一)
        /// </summary>
        protected EFDbContext DbContext = DbContextFactory.GetCurrentDbContext();

        #region 查询
        /// <summary>
        /// 获取当前实体的查询数据集
        /// </summary>
        public virtual IQueryable<TEntity> Entities
        {
            get { return DbContext.Set<TEntity>(); }
        }
        /// <summary>
        /// (贪婪加载)查询返回指定实体数据集
        /// </summary>
        /// <param name="includeList">贪婪加载属性集合</param>
        /// <returns>指定实体数据集</returns>
        public virtual IQueryable<TEntity> GetEntitiesByEager(IEnumerable<string> includeList)
        {
            IQueryable<TEntity> dbSet = DbContext.Set<TEntity>();
            return includeList.Aggregate(dbSet, (current, item) => current.Include<TEntity>(item));
        }
        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="key">指定主键</param>
        /// <returns>符合编号的记录，不存在返回null</returns>
        public TEntity GetByKey(TKey key)
        {
            PublicHelper.CheckArgument(key, "key");
            return DbContext.Set<TEntity>().Find(key);
        }
        #endregion

        #region 增加
        /// <summary>
        /// 插入实体记录
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响的行数</returns>
        public virtual int Insert(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EntityState state = DbContext.Entry(entity).State;
            if (state == EntityState.Detached)
            {
                DbContext.Entry(entity).State = EntityState.Added;
            }
            return isSave ? DbContext.SaveChanges() : 0;
        }
        /// <summary>
        /// 批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            DbContext.Configuration.AutoDetectChangesEnabled = false;//关闭自动检测属性状态更改，提升性能
            foreach (TEntity entity in entities)
            {
                EntityState state = DbContext.Entry(entity).State;
                if (state == EntityState.Detached)
                {
                    DbContext.Entry(entity).State = EntityState.Added;
                }
            }
            DbContext.Configuration.AutoDetectChangesEnabled = true;//恢复自动检测
            return isSave ? DbContext.SaveChanges() : 0;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除指定主键的记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响的行数</returns>
        public int Delete(TKey id, bool isSave = true)
        {
            PublicHelper.CheckArgument(id, "id");
            TEntity entity = DbContext.Set<TEntity>().Find(id);
            return entity != null ? Delete(entity, isSave) : 0;
        }
        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public int Delete(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            DbContext.Entry(entity).State = EntityState.Deleted;
            return isSave ? DbContext.SaveChanges() : 0;
        }
        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            DbContext.Configuration.AutoDetectChangesEnabled = false; //关闭自动检测属性状态更改，关闭提升性能
            foreach (TEntity entity in entities)
            {
                DbContext.Entry(entity).State = EntityState.Deleted;
            }
            DbContext.Configuration.AutoDetectChangesEnabled = true;//恢复自动检测
            return isSave ? DbContext.SaveChanges() : 0;
        }
        /// <summary>
        ///    删除所有符合特定表达式的数据（EntityFramework.Extensions扩展））,用法详见https://github.com/loresoft/EntityFramework.Extended
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public int Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            PublicHelper.CheckArgument(predicate, "predicate");
            DbContext.Set<TEntity>().Where(predicate).Delete();
            return isSave ? DbContext.SaveChanges() : 0;
        }
        #endregion

        #region 更新
        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entities"> 实体对象集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public int Update(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            foreach (TEntity entity in entities)
            {
                DbSet<TEntity> dbSet = DbContext.Set<TEntity>();
                try
                {
                    DbEntityEntry<TEntity> entry = DbContext.Entry(entity);
                    if (entry.State == EntityState.Detached)
                    {
                        dbSet.Attach(entity);
                        entry.State = EntityState.Modified;
                    }
                }
                catch (InvalidOperationException)
                {
                    //当同一上下文中存在相同主键的实体时，上面的attach操作将会报错，因为EF状态跟踪ObjectStateManager跟无法跟踪具有相同键的多个对象，所以需要执行下面的代码把新数据赋到现有实体上
                    TEntity oldEntity = dbSet.Find(entity.Id);
                    DbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
                }
            }
            return isSave ? DbContext.SaveChanges() : 0;
        }
        /// <summary>
        /// （扩展）修改所有符合特定表达式的数据（EntityFramework.Extensions扩展）,用法详见https://github.com/loresoft/EntityFramework.Extended
        /// </summary>
        /// <param name="filter">查询条件谓语表达式</param>
        /// <param name="updateExperssion">需要修改的字段谓词表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <returns>操作影响的行数</returns>
        public int Update(IQueryable<TEntity> filter, Expression<Func<TEntity, TEntity>> updateExpression, bool isSave = true)
        {
            this.Entities.Update(filter, updateExpression);
            return isSave ? DbContext.SaveChanges() : 0;
        }
        #endregion

    }
}
