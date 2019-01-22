using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Generals.Base;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class RepositoryWithCompany<TEntity> : GenericRepository<TEntity>, IRepositoryWithCompany<TEntity>
         where TEntity : EntityWithCompany
    {
        public RepositoryWithCompany(DbContextGeneric _dbContext) : base(_dbContext)
        {

        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync(string companyId)
        {
            return dbSet.Where(e => e.Deleted == false &&
                                               e.CompanyId == companyId)
                                    .AsNoTracking();
        }


        public virtual async Task<TEntity> GetByIdAsync(string companyId, string id)
        {
            return await dbSet.Where(e => e.Deleted == false &&
                                                e.CompanyId == companyId &&
                                                e.Id == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
        }
    }

}
