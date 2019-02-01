using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Interfaces;
using Domain.Core.Models;
using Framework.NetCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class GenericRepository<TEntity> : IRepositoryGeneric<TEntity> where TEntity : Entity
    {
        protected readonly IDbContextGeneric Db;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(IDbContextGeneric _dbContext)
        {
            Db = _dbContext;
            DbSet = Db.Set<TEntity>();
        }




        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return DbSet.Where(e => e.Deleted == false)
                            .AsNoTracking();
        }


        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            var oEntity = await DbSet.Where(e => e.Deleted == false &&
                                    e.Id == id)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();

            if (oEntity == null)
            {
                //modelNotification.Add($"registo {id} não localizado");
                return null;
            }


            return oEntity;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity.Deleted)
            {
                //modelNotification.Add("Registro Deletado nao pode ser incluido!");
                return null;
            }

            //if (!modelNotification.isValid)
            //     return null;


            entity.RemoveEntityBaseProperty();
            await DbSet.AddAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity.Deleted)
            {
                //modelNotification.Add("Registro Deletado nao pode ser alterado!");
                return null;
            }


            entity.Update(entity.CreatedBy);


            //if (!modelNotification.isValid)
            //    return null;

            entity.RemoveEntityBaseProperty();
            DbSet.Update(entity);

          
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TEntity _entity)
        {
            var entity = await GetByIdAsync(_entity.Id);


            if (entity.Deleted)
            {
                //modelNotification.Add("Registro já Deletado!");
                return false;
            }



            if (entity == null)
                return false;

            //if (!modelNotification.isValid)
            //     return false;

            entity.Delete(_entity.CreatedBy);

            //dont delete fisicaly only logical
            DbSet.Update(entity);

               return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }
    }




}
