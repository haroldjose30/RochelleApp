using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Base;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Base
{
    public class GenericRepositoryEntityWithCompany<TEntity> : GenericRepositoryEntity<TEntity>,
        IGenericRepositoryEntityWithCompany<TEntity>
         where TEntity : EntityWithCompany
    {
        public GenericRepositoryEntityWithCompany(DbContextGeneric dbContext) : base(dbContext)
        {

        }
        
        public async Task<TEntity> GetById(Guid companyId, Guid id)
        {
            //define filter 
            Expression<Func<TEntity, bool>> filterByCompanyIdDeleted = e => e.Id == id && e.CompanyId == companyId && e.Deleted == false;
            return await base.GetFirstOrDefault(filterByCompanyIdDeleted);
        }
        
        public async Task<IEnumerable<TEntity>> GetAll(Guid companyId)
        {
            //define filter 
            Expression<Func<TEntity, bool>> filterByCompanyDeleted = e => e.CompanyId == companyId && e.Deleted == false;
            return await base.Get(filterByCompanyDeleted);

        }

       
    }

}