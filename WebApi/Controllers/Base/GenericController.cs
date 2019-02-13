using System.Threading.Tasks;
using Domain.Core.Models;
using Domain.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{

    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : Entity
    {
         protected readonly IGenericService<TEntity> service;
  
        public GenericController(IGenericService<TEntity> _service)
        {
            service = _service;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Entity>))]
        //[ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get()
        {
            var oEntities = service.GetAll();

            if (oEntities != null)
                return Ok(oEntities);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        //[ProducesResponseType(200, Type = typeof(Entity))]
        //[ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get(string id)
        {
            var oEntity = service.GetById(id);

            if (oEntity != null)
                return Ok(oEntity);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]TEntity entity)
        {
            var oEntity = service.Register(entity);

            if (oEntity != null)
                return Ok(oEntity);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody]TEntity entity)
        {
            var oEntity = service.Update(entity);
            if (oEntity != null )
                return Ok(oEntity);
            else
                return BadRequest();
        }

        //[Authorize("Bearer")]
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(string id, string deletedBy)
        {
             var lOk = service.Remove(id,deletedBy);
            if (lOk)
                return Ok(lOk);
            else
                return BadRequest();
        }
    }

  

}

