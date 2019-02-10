using System;
using Domain.Core.Models;

namespace Domain.Core.Events
{
    public class GenericUpdatedEvent<TEntity> : EventNotification where TEntity : Entity
    {
        TEntity entity;
        public GenericUpdatedEvent(TEntity _entity)
        {
            entity = _entity;
        }
    }
}
