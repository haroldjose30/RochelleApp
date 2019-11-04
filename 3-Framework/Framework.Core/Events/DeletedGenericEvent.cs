using Framework.Core.Models;

namespace Framework.Core.Events
{
    public class DeletedGenericEvent<TEntity> : EventNotification where TEntity : Entity
    {
        public TEntity Entity { get;}
        public DeletedGenericEvent(TEntity entity)
        {
            this.Entity = entity;
        }
    }

}
