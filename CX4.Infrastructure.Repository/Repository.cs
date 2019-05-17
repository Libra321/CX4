/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/14 15:45:26
 ****** 功能描述    ：Repository
 *******************************************************************************/

using CX4.Domain.Core.Models;
using CX4.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CX4.Infrastructure.Repository
{
    /// <summary>
    ///默认主键为int类型的仓储基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : Repository<TEntity, int> where TEntity : Entity<int>
    {
    }

    /// <summary>
    ///
    /// </summary>
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract IQueryable<TEntity> GetAll();

        #region 新增

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public abstract TEntity Insert(TEntity entity);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        #endregion 新增

        #region 查找

        /// <summary>
        /// 返回满足条件的第一个元素或者默认值
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 返回满足条件的第一个元素或者默认值
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        /// <summary>
        /// 根据主键查找
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public virtual TEntity Get(TKey key)
        {
            return FirstOrDefault(CreateEqualExpressionForKey(key));
        }

        /// <summary>
        ///根据主键查找
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public virtual Task<TEntity> GetAsync(TKey key)
        {
            return Task.FromResult(Get(key));
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual Task<ICollection<TEntity>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        /// <summary>
        /// 查找满足条件的集合
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public virtual ICollection<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        /// <summary>
        /// 查找满足条件的集合
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public virtual Task<ICollection<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Query(predicate));
        }

        #endregion 查找

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public abstract TEntity Update(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        #endregion 更新

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public abstract void Delete(TKey key);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        public virtual Task DeleteAsync(TKey key)
        {
            Delete(key);
            return Task.FromResult(true);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var list = GetAll().Where(predicate).ToList();
            foreach (var entity in list)
            {
                Delete(entity.ID);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(true);
        }

        #endregion 删除

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected virtual Expression<Func<TEntity, bool>> CreateEqualExpressionForKey(TKey key)
        {
            var typeEntity = typeof(TEntity);
            var paramExpression = Expression.Parameter(typeEntity, "k");
            var memberExpression = Expression.PropertyOrField(paramExpression, "ID");
            var constantExpression = Expression.Constant(key, typeof(TKey));
            var methodCallExpression = Expression.Call(memberExpression, typeEntity.GetMethod("Equals"), constantExpression);
            return Expression.Lambda<Func<TEntity, bool>>(methodCallExpression, paramExpression);
        }
    }
}
