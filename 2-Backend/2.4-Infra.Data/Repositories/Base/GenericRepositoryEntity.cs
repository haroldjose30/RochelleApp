using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Base
{
    public class GenericRepositoryEntity<TEntity> : GenericRepository<TEntity>,IGenericRepositoryEntity<TEntity> where TEntity : Entity
    {
        public GenericRepositoryEntity(DbContextGeneric context) : base(context)
        {
            
        }
        
        public virtual async Task<TEntity> GetById(Guid id)
        { 
            //define filter
           Expression<Func<TEntity, bool>> filterBy = e => e.Id == id && e.Deleted == false;
           return await base.GetFirstOrDefault(filterBy);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            Expression<Func<TEntity, bool>> filterBy = e =>  e.Deleted == false;
            return await base.Get(filterBy);
        }


       
    }



}
