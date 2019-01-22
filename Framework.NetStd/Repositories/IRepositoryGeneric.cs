using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.NetStd.Models;

namespace Framework.NetStd.Repositories
{
    public interface IRepositoryGeneric<TEntity>: IDisposable where TEntity : Entity
    {
        Task<IQueryable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(ModelNotification modelError,string id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(ModelNotification modelNotification,TEntity entity);

        Task<int> SaveChangesAsync();
    }


}
