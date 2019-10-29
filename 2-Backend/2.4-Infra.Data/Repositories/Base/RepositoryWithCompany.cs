/*
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Generals.Base;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class RepositoryWithCompany<TEntity> : Repository<TEntity>, IRepositoryWithCompany<TEntity>
         where TEntity : EntityWithCompany
    {
        public RepositoryWithCompany(DbContextGeneric _dbContext) : base(_dbContext)
        {

        }

        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync(string companyId)
        {
            return DbSet.Where(e => e.Deleted == false &&
                                               e.CompanyId == companyId)
                                    .AsNoTracking();
        }

        public TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> GetByIdAsync(string companyId, string id)
        {
            return await DbSet.Where(e => e.Deleted == false &&
                                                e.CompanyId == companyId &&
                                                e.Id == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }

}
*/