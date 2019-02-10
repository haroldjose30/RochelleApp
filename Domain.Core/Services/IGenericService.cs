using System.Collections.Generic;
using Domain.Core.Models;

namespace ApplicationBusiness.Services
{

    public interface IGenericService<TEntity> where TEntity : Entity
    {
        TEntity Register(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(string id);
        TEntity Update(TEntity entity);
        bool Remove(string id, string deletedBy);
    }

}