using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{

    public interface IGenericRepositoryEntity<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
