using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    private readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(DbContextGeneric context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
 
    public virtual async Task<IEnumerable<TEntity>>  Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
 
        foreach (Expression<Func<TEntity, object>> include in includes)
            query = query.Include(include);
 
        if (filter != null)
            query = query.Where(filter);
 
        if (orderBy != null)
            query = orderBy(query);
 
        return await query.ToListAsync();
    }
 
    protected IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        IQueryable<TEntity> query = _dbSet;
 
        if (filter != null)
            query = query.Where(filter);
 
        if (orderBy != null)
            query = orderBy(query);
 
        return query;
    }

    public virtual  async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
 
        foreach (Expression<Func<TEntity, object>> include in includes)
            query = query.Include(include);
        
 
        return await query.FirstOrDefaultAsync(filter);
    }
 
    public virtual async Task<TEntity> Insert(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }
 
    public virtual async Task<TEntity> Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return await Task.FromResult(entity);
    }

    public async Task<bool> DeleteLogically(Guid id, string deletedBy)
    {
        var entity = await _dbSet.Where(e => e.Id == id && e.Deleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        entity.Delete(deletedBy);

        await Update(entity);

        return true;
    }

    public async Task<bool> DeletePhysically(Guid id)
    {
        _dbSet.Remove(_dbSet.Find(id));
        return await Task.FromResult(true);
    }
    

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
}