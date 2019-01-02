using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationBusiness.Validators;
using Domain.Models.Base;
using FluentValidation;
using Infra.Data.Repositories.Base;

namespace ApplicationBusiness.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> repository;
        private readonly Validator<TEntity> validator;

        public Service(IRepository<TEntity> _repository, Validator<TEntity> _validator)
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

        public virtual async Task<Boolean> DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("The id can't be empty.");

            await repository.DeleteAsync(entity);
            return true;
        }

        public virtual async Task<IQueryable<TEntity>> GetAllAsync() 
        { 
            return await repository.GetAllAsync(); 
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            if (id == string.Empty)
                throw new ArgumentException("The id can't be empty.");

            return await repository.GetByIdAsync(id);
        }

        private void Validate(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(entity);
        }
    }
}


