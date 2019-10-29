using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Update(TEntity obj);
        Task<bool> Remove(string id, string removedBy);
        Task<int> SaveChangesAsync();
    }
}
