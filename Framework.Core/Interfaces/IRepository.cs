using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity obj);
        TEntity GetById(string id);
        IQueryable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        bool Remove(string id, string removedBy);
        Task<int> SaveChangesAsync();
    }
}
