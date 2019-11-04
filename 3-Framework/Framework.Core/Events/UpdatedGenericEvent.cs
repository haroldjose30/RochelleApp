using Framework.Core.Models;

namespace Framework.Core.Events
{
    public class UpdatedGenericEvent<TEntity> : EventNotification where TEntity : Entity
    {
        public TEntity Entity { get;}
        public UpdatedGenericEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}
