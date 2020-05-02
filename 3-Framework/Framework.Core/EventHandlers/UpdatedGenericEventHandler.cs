using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.EventHandlers
{
    public class UpdatedGenericEventHandler<TEntity> : INotificationHandler<UpdatedGenericEvent<TEntity>> where TEntity : Entity
    {
        public virtual Task Handle(UpdatedGenericEvent<TEntity> notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("UpdatedGenericEventHandler.Handle");

            return Task.CompletedTask;
        }

       
    }
}
