using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Base;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class RepositoryWithCompany<TEntity> : Repository<TEntity>, IRepositoryWithCompany<TEntity>
         where TEntity : EntityWithCompany
    {
        public RepositoryWithCompany(DbSqlContext _dbContext) : base(_dbContext)
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

        public override string GetNewId(TEntity entity)
        {
            var cNewId = DateTime.Now.ToUniversalTime().ToString("yyMMddHHmmssfff");

            if (string.IsNullOrWhiteSpace(entity.CompanyId))
                cNewId += entity.CompanyId.Trim();

            if (string.IsNullOrWhiteSpace(entity.CreatedBy))
                cNewId += entity.CreatedBy.Trim();

            return cNewId;

        }
    }

}
