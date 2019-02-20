using System;
using Framework.Core.Models;

namespace Framework.Core.Events
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
