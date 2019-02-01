using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Models;

namespace Domain.Core.Interfaces
{

    public interface IRepositoryGeneric<TEntity>: IRepositoryGenericWrite<TEntity>, IRepositoryGenericRead<TEntity> where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);


        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }



    public interface IRepositoryGenericWrite<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();

    }

    public interface IRepositoryGenericRead<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
    }


}
