using System;
using Framework.Core.Models;

namespace Framework.Core.Events
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
