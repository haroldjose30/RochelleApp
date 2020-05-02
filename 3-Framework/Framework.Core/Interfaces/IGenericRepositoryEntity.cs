using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{

    public interface IGenericRepositoryEntity<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Insert(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task<bool> Delete(Guid id, string removedBy);
        Task<int> SaveChangesAsync();
    }
}
