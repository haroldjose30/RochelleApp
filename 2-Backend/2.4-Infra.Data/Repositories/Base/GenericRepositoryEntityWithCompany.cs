using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class GenericRepositoryEntityWithCompany<TEntity> : GenericRepositoryEntity<TEntity>,
        IGenericRepositoryEntityWithCompany<TEntity>
         where TEntity : EntityWithCompany
    {
        public GenericRepositoryEntityWithCompany(DbContextGeneric dbContext) : base(dbContext)
        {

        }
        
        //todo: harold - passar a classe base para programacao funcionar para podeder passar o metodo query por funcao e nao precisar duplicar as funcoes

        public async Task<IEnumerable<TEntity>> GetAll(Guid companyId)
        {
            return await _dbSet.Where(e => e.CompanyId == companyId && e.Deleted == false)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> GetById(Guid companyId, Guid id)
        {
            return await _dbSet.Where(e => e.Id == id && e.CompanyId == companyId && e.Deleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }

}