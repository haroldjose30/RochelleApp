﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Framework.NetCore.Contexts;
using Framework.NetStd.Models;
using Framework.NetStd.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class GenericRepository<TEntity> : IRepositoryGeneric<TEntity> where TEntity : Entity
    {
        public bool lAutoSaveChanges = true;

        protected readonly IDbContextGeneric dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public GenericRepository(IDbContextGeneric _dbContext)
        {

            dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return dbSet.Where(e => e.Deleted == false)
                            .AsNoTracking();
        }

        public virtual async Task<TEntity> GetByIdAsync(ModelNotification modelError,string id)
        {
            var oEntity = await dbSet.Where(e => e.Deleted == false &&
                                    e.Id == id)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

            if (oEntity == null)
            {
                modelError.Add($"registo {id} não localizado");
                return null;
            }


            return oEntity;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
          

            if (entity.Deleted)
                throw new Exception("Registro Deletado nao pode ser incluido!");

            entity.RemoveEntityBaseProperty();
            await dbSet.AddAsync(entity);

            if (lAutoSaveChanges)
                await SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity.Deleted)
                throw new Exception("Registro Deletado nao pode ser alterado!");

            entity.Update(entity.CreatedBy);

            entity.RemoveEntityBaseProperty();
            dbSet.Update(entity);

            if (lAutoSaveChanges)
                await SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(ModelNotification modelNotification, TEntity _entity)
        {
             var entity = await GetByIdAsync(modelNotification,_entity.Id);


            if (entity.Deleted)
            {
                modelNotification.Add("Registro já Deletado!");
                //throw new Exception("Registro já Deletado!");
                return false;
            }



            if (entity == null)
                return false;

            entity.Delete(_entity.CreatedBy);

            //dont delete fisicaly only logical
            dbSet.Update(entity);


            if (lAutoSaveChanges)
                await SaveChangesAsync();

            return true;
        }
        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }




}
