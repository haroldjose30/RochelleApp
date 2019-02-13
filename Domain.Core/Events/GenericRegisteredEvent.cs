using System;
using Domain.Core.Models;

namespace Domain.Core.Events
{
    public class GenericRegisteredEvent<TEntity>: EventNotification where TEntity : Entity
    {
        TEntity entity;
        public GenericRegisteredEvent(TEntity _entity)
        {
            entity = _entity;
        }
    }
}
