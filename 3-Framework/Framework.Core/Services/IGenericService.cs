using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core.Models;

namespace Framework.Core.Services
{

    public interface IGenericService<TEntity> where TEntity : Entity
    { 
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(Guid id, string deletedBy);
    }

}