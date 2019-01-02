using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Infra.Data.Repositories.Base
{
    public interface IRepository<TEntity>: IDisposable where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TEntity entity);

        Task<int> SaveChangesAsync();
    }


}
