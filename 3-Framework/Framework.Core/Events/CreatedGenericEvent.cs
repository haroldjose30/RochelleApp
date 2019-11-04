using Framework.Core.Models;

namespace Framework.Core.Events
{
    public class CreatedGenericEvent<TEntity>: EventNotification where TEntity : Entity
    {
        public TEntity Entity { get;}
        public CreatedGenericEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}
