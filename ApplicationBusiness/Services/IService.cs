using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Base;
using FluentValidation;

namespace ApplicationBusiness.Services
{
    public interface IService<TEntity> where TEntity : Entity
    {

        Task<TEntity> CreateAsync(TEntity obj);

        Task<TEntity> UpdateAsync(TEntity obj);

        Task<Boolean> DeleteAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(string id);

        Task<IQueryable<TEntity>> GetAllAsync();
    }
}