using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Base;
using Infra.Data.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    public class RepositoryController<TEntity> : ControllerBase where TEntity : Entity
    {
        protected readonly IRepository<TEntity> repository;

        public RepositoryController(IRepository<TEntity> _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public virtual async Task<IQueryable<TEntity>> Get()
        {
            return await repository.GetAllAsync();
        }


        [HttpGet("{id}")]
        public virtual async Task<TEntity> Get(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<TEntity> Post([FromBody]TEntity entity)
        {
            return await repository.CreateAsync(entity);
        }

        [HttpPut]
        public virtual async Task<TEntity> Put([FromBody]TEntity entity)
        {
            return await repository.UpdateAsync(entity);
        }

        [HttpDelete]
        public virtual async Task<bool> Delete([FromBody]TEntity entity)
        {
            return await repository.DeleteAsync(entity);
        }
    }
}

