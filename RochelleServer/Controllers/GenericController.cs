using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RochelleServer.Repositories;
using RochelleShared.Models;

namespace RochelleServer.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : EntityBase
    {
        private readonly IGenericRepository<TEntity> repository;

        public GenericController(IGenericRepository<TEntity> _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<IEnumerable<TEntity>> Get()
        {
            return await repository.GetAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<TEntity> Get(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<TEntity> Post([FromBody]TEntity entity)
        {
            return await repository.CreateAsync(entity);
        }

        [HttpPut]
        public async Task<TEntity> Put([FromBody]TEntity entity)
        {
            return await repository.UpdateAsync(entity);
        }

        [HttpDelete]
        public async Task<bool> Delete([FromBody]TEntity entity)
        {
            return await repository.DeleteAsync(entity);
        }
    }
}

