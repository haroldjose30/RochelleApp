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
        protected readonly DbContextGeneric Db;
        protected readonly DbSet<TEntity> dbset;

        public Repository(DbContextGeneric context)
        {
            Db = context;
            dbset = Db.Set<TEntity>();
        }


        public virtual TEntity Add(TEntity entity)
        {
           dbset.Add(entity);
           return entity;
        }

        public virtual TEntity GetById(string id)
        {
            return dbset.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbset;
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbset.Update(entity);
            return entity;
        }

        public bool Remove(string id, string removedBy)
        {
            dbset.Remove(dbset.Find(id));
            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

      
    }



}
