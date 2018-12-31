using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RochelleShared.Models;

namespace RochelleServer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : EntityBase
    {
        private readonly RochelleDbContext _dbContext;
        public GenericRepository(RochelleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return  _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            RemoveEntityBaseProperty(entity);
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            RemoveEntityBaseProperty(entity);
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TEntity _entity)
        {
            var entity = await GetByIdAsync(_entity.Id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //remove all ForeingKey/EntityBase property from object, using reflexions
        private void RemoveEntityBaseProperty(TEntity entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            //var propertiesEntitybase = properties.Where(p => p.PropertyType?.BaseType == typeof(EntityBase));

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.BaseType == typeof(EntityBase))
                {
                    Console.WriteLine($"EntityBase={property.Name}=null");
                    property.SetValue(entity,null);
                    continue;
                }

                if (property.PropertyType.BaseType == typeof(EntityBaseCompany))
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
    }




}
