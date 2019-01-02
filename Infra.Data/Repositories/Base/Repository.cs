using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Models.Base;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public bool lAutoSaveChanges = true;

        protected readonly DbSqlContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(DbSqlContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return dbSet.Where(e => e.Deleted == false)
                            .AsNoTracking();
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await dbSet.Where(e => e.Deleted == false &&
                                    e.Id == id)
                            .AsNoTracking()
                            .FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {

            //if id is empyty, get new id automaticaly
            if (String.IsNullOrWhiteSpace(entity.Id))
                entity.Id = GetNewId(entity);

            //update inserted date
            entity.Deleted = false;
            entity.CreatedDate = GetDateTime();
            entity.ModifiedDate = entity.CreatedDate;

            RemoveEntityBaseProperty(entity);
            await dbSet.AddAsync(entity);

            if (lAutoSaveChanges)
                await SaveChangesAsync();

            return entity;
        }

        public virtual string GetNewId(TEntity entity)
        {
            var cNewId = DateTime.Now.ToUniversalTime().ToString("yyMMddHHmmssfff");

            if (string.IsNullOrWhiteSpace(entity.CreatedBy))
                cNewId += entity.CreatedBy.Trim();

            return cNewId;

        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.ModifiedDate = GetDateTime();

            RemoveEntityBaseProperty(entity);
            dbSet.Update(entity);

            if (lAutoSaveChanges)
                await SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TEntity _entity)
        {

            var entity = await GetByIdAsync(_entity.Id);

            if (entity == null)
                return false;


            entity.ModifiedDate = GetDateTime();
            entity.Deleted = true;
            //dont delete fisicaly only logical
            dbSet.Update(entity);


            if (lAutoSaveChanges)
                await SaveChangesAsync();

            return true;
        }

        //remove all ForeingKey/EntityBase property from object, using reflexions
        public static void RemoveEntityBaseProperty(TEntity entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            //var propertiesEntitybase = properties.Where(p => p.PropertyType?.BaseType == typeof(EntityBase));

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.BaseType == typeof(Entity))
                {
                    Console.WriteLine($"EntityBase={property.Name}=null");
                    property.SetValue(entity, null);
                    continue;
                }

                if (property.PropertyType.BaseType == typeof(EntityWithCompany))
                {
                    Console.WriteLine($"EntityBaseCompany={property.Name}=null");
                    property.SetValue(entity, null);
                    continue;
                }


                if (property.PropertyType.Namespace.Equals("System.Collections.Generic"))
                {
                    Console.WriteLine($"System.Collections.Generic={property.Name}=null");
                    property.SetValue(entity, null);
                    continue;
                }
            }


        }

        /// <summary>
        /// Return date time on format yyyyMMdd HH:mm:ss
        /// </summary>
        /// <returns>The date time.</returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
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
