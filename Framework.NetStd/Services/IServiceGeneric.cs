using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.NetStd.Models;

namespace Framework.NetStd.Services
{
    public interface IServiceGeneric<TEntity> where TEntity : Entity
    {

        Task<TEntity> CreateAsync(TEntity obj);

        Task<TEntity> UpdateAsync(TEntity obj);

        Task<Boolean> DeleteAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(string id);

        Task<IQueryable<TEntity>> GetAllAsync();
    }
}