using System.Linq;
using System.Threading.Tasks;
using Framework.NetStd.Models;
using Framework.NetStd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : Entity
    {
        protected readonly IServiceGeneric<TEntity> service;

        public GenericController(IServiceGeneric<TEntity> _service)
        {
            service = _service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public virtual async Task<IQueryable<TEntity>> Get()
        {
            return await service.GetAllAsync();
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public virtual async Task<TEntity> Get(string id)
        {
            return await service.GetByIdAsync(id);
        }

        [Authorize("Bearer")]
        [HttpPost]
        public virtual async Task<TEntity> Post([FromBody]TEntity entity)
        {
            return await service.CreateAsync(entity);
        }

        [Authorize("Bearer")]
        [HttpPut]
        public virtual async Task<TEntity> Put([FromBody]TEntity entity)
        {
            return await service.UpdateAsync(entity);
        }

        [Authorize("Bearer")]
        [HttpDelete]
        public virtual async Task<bool> Delete([FromBody]TEntity entity)
        {
            return await service.DeleteAsync(entity);
        }
    }
}

