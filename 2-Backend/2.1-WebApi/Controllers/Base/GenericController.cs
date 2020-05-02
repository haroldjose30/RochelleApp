using System;
using System.Threading.Tasks;
using Framework.Core.Models;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
   
    public class GenericController<TEntity> : ApiController where TEntity : Entity
    {
         protected readonly IGenericService<TEntity> _service;
       
        public GenericController(IGenericService<TEntity> service, INotificationHandler<DomainNotification> notificationHandler) : base(notificationHandler)
        {
            this._service = service;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Entity>))]
        //[ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get()
        {
            var entities = await _service.GetAll();
            return Response(entities);
        }

        //[Authorize("Bearer")]
        [HttpGet("{id}")]
        //[ProducesResponseType(200, Type = typeof(Entity))]
        //[ProducesResponseType(404)]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            var entity = await _service.GetById(id);
            return Response(entity);
        }
    

        //[Authorize("Bearer")]
        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(entity);
            }

             var oEntity = await _service.Create(entity);

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

            var oEntity = await _service.Update(entity);
            return Response(oEntity);
        }

        //[Authorize("Bearer")]
        [HttpDelete()]
        public virtual async Task<IActionResult> Delete([FromQuery]Guid id, [FromQuery]string deletedBy)
        {
             var lOk = await _service.Delete(id,deletedBy);
            return Response(lOk);
        }
    }

  

}

