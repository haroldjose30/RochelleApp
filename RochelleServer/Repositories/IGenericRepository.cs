using System;
using System.Linq;
using System.Threading.Tasks;
using RochelleShared.Models;

namespace RochelleServer.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task<IQueryable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);
    }
}
