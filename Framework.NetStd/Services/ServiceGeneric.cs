using System;
using System.Linq;
using System.Threading.Tasks;
using Framework.NetStd.Models;
using Framework.NetStd.Repositories;
using Framework.NetStd.Validators;

namespace Framework.NetStd.Services
{
    public class ServiceGeneric<TEntity> : IServiceGeneric<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryGeneric<TEntity> repository;
        private readonly IValidatorGeneric<TEntity> validator;

        public ServiceGeneric(IRepositoryGeneric<TEntity> _repository, IValidatorGeneric<TEntity> _validator)
        {
            repository = _repository;
            validator = _validator;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            Validate(entity);

            await repository.CreateAsync(entity);
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Validate(entity);

            await repository.UpdateAsync(entity);
            return entity;
        }

        public virtual async Task<Boolean> DeleteAsync(ModelNotification modelNotification,TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("The id can't be empty.");

            await repository.DeleteAsync(modelNotification,entity);
            return true;
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync() 
        { 
            return await repository.GetAllAsync(); 
        }

        public virtual async Task<TEntity> GetByIdAsync(ModelNotification modelNotification, string id)
        {
            if (id == string.Empty)
            {
                modelNotification.Add("id não pode ser vazio!");
                //throw new ArgumentException("The id can't be empty.");
                return null;
            }


            return await repository.GetByIdAsync(modelNotification, id);
        }

        private void Validate(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Registros não detectados!");

            //validator.ValidateAndThrow(entity);
           var oValidator = validator.Validate(entity);
        }
    }
}


