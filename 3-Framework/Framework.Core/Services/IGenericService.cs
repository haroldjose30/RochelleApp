using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Services
{

    public interface IGenericService<TEntity> where TEntity : Entity
    {
        Task<TEntity> RegisterAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> RemoveAsync(string id, string deletedBy);
    }

}