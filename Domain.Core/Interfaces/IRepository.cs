using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Models;

namespace Domain.Core.Interfaces
{

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Add(TEntity obj);
        TEntity GetById(string id);
        IQueryable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        bool Remove(string id);
        Task<int> SaveChangesAsync();
    }
}
