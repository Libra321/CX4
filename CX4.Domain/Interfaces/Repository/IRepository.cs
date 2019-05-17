/********************************************************************************
 ****** 创 建 者    ：pengdong
 ****** 创建日期    ：2019/5/14 15:34:07
 ****** 功能描述    ：IRepository
 *******************************************************************************/

using CX4.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CX4.Domain.Interfaces.Repository
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : Entity<int>
    {
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        #region 新增

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        Task InsertAsync(TEntity entity);

        #endregion 新增

        #region 查找

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查找根据主键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get(TKey key);

        /// <summary>
        ///查找根据主键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey key);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> GetAllList();

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> GetAllListAsync();

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion 查找

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> UpdateAsync(TEntity entity);

        #endregion 更新

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        void Delete(TKey key);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        Task DeleteAsync(TKey key);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate"></param>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion 删除
    }
}
