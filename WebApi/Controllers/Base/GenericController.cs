using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models;
using Framework.NetStd.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : Entity
    {
        protected readonly IMediator mediator;
        protected readonly IServiceGeneric<TEntity> service;
  
        public GenericController(IMediator _mediator,IServiceGeneric<TEntity> _service)
        {
            service = _service;
            mediator = _mediator;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Entity>))]
        [ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get()
        {
            var oEntities = await service.GetAllAsync();

            if (oEntities != null)
                return Ok(oEntities);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Entity))]
        [ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get(string id)
        {
            var oEntity = await service.GetByIdAsync(id);

            if (oEntity != null)
                return Ok(oEntity);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]TEntity entity)
        {
            var oEntity = await service.CreateAsync(entity);

            if (oEntity != null)
                return Ok(oEntity);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody]TEntity entity)
        {
            var oEntity = await service.UpdateAsync(entity);
            if (oEntity != null )
                return Ok(oEntity);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromBody]TEntity entity)
        {
            var lOk = await service.DeleteAsync(entity);
            if (lOk)
                return Ok(lOk);
            else
                return BadRequest();
        }
    }

  

}

