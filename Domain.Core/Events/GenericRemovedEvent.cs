using System;
using Domain.Core.Models;

namespace Domain.Core.Events
{
    public class GenericRemovedEvent<TEntity> : EventNotification where TEntity : Entity
    {
        TEntity entity;
        public GenericRemovedEvent(TEntity _entity)
        {
            entity = _entity;
        }
    }

}
