using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContextGeneric _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContextGeneric context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }


        public virtual async Task<TEntity> Add(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
           return entity;
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return await Task.FromResult<IQueryable<TEntity>>(_dbSet);
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        public async Task<bool> Remove(string id, string removedBy)
        {
            _dbSet.Remove(_dbSet.Find(id));
            return await Task.FromResult(true);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }



}
