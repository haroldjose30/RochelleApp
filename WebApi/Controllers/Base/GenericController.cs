using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{

    [Route("api/[controller]")]
    public class GenericController<TEntity> : ApiController where TEntity : Entity
    {
         protected readonly IGenericService<TEntity> service;
       
        public GenericController(IGenericService<TEntity> _service, INotificationHandler<DomainNotification> _notificationHandler) : base(_notificationHandler)
        {
            service = _service;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Entity>))]
        //[ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get()
        {
            var entities = await service.GetAll();
            return Response(entities);
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        //[ProducesResponseType(200, Type = typeof(Entity))]
        //[ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get(string id)
        {
            var entity = await service.GetById(id);
            return Response(entity);
        }
    

        //[Authorize("Bearer")]
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody]TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(entity);
            }

             var oEntity = await service.RegisterAsync(entity);

            return Response(oEntity);
        }

        //[Authorize("Bearer")]
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody]TEntity entity)
        {

            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(entity);
            }

            var oEntity = await service.UpdateAsync(entity);
            return Response(oEntity);
        }

        //[Authorize("Bearer")]
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(string id, string deletedBy)
        {
             var lOk = await service.RemoveAsync(id,deletedBy);
            return Response(lOk);
        }
    }

  

}

