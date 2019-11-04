using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContextGeneric _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContextGeneric context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }


        public virtual async Task<TEntity> Insert(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
           return entity;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.Where(e => e.Id == id && e.Deleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.Where(e => e.Deleted == false)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        public async Task<bool> Delete(Guid id, string removedBy)
        {
            _dbSet.Remove(_dbSet.Find(id));
            return await Task.FromResult(true);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }



}
