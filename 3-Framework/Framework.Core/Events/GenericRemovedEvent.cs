using Framework.Core.Models;

namespace Framework.Core.Events
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
