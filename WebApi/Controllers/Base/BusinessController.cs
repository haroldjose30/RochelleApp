﻿using System.Linq;
using System.Threading.Tasks;
using ApplicationBusiness.Services;
using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    public class BusinessController<TEntity> : ControllerBase where TEntity : Entity
    {
        protected readonly Service<TEntity> service;

        public BusinessController(Service<TEntity> _service)
        {
            service = _service;
        }


        [HttpGet]
        public virtual async Task<IQueryable<TEntity>> Get()
        {
            return await service.GetAllAsync();
        }


        [HttpGet("{id}")]
        public virtual async Task<TEntity> Get(string id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<TEntity> Post([FromBody]TEntity entity)
        {
            return await service.CreateAsync(entity);
        }

        [HttpPut]
        public virtual async Task<TEntity> Put([FromBody]TEntity entity)
        {
            return await service.UpdateAsync(entity);
        }

        [HttpDelete]
        public virtual async Task<bool> Delete([FromBody]TEntity entity)
        {
            return await service.DeleteAsync(entity);
        }
    }
}

