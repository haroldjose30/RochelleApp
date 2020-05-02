using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.EventHandlers
{
    public class DeletedGenericEventHandler<TEntity> : INotificationHandler<DeletedGenericEvent<TEntity>> where TEntity : Entity
    {
        public virtual Task Handle(DeletedGenericEvent<TEntity> notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("DeletedGenericEventHandler.Handle");

            return Task.CompletedTask;
        }
    }
}
