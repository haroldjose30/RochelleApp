using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{
    public interface IGenericRepository<TEntity>:IDisposable where TEntity : Entity
    {
        /// <summary>
        /// Get all entities from db
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
     
        /// <summary>
        /// Get first or default entity by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity> GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);
 
        /// <summary>
        /// Insert entity to db
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> Insert(TEntity entity);
 
        /// <summary>
        /// Update entity in db
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> Update(TEntity entity);

        /// <summary>
        /// Delete entity from db by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deletedBy"></param>
        Task<bool> DeleteLogically(Guid id,string deletedBy);
        
        
        /// <summary>
        /// Delete entity from db by primary key
        /// </summary>
        /// <param name="id"></param>
        Task<bool> DeletePhysically(Guid id);
    }
}