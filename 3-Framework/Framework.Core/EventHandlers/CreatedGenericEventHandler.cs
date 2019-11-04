using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.EventHandlers
{
    public class CreatedGenericEventHandler<TEntity> : INotificationHandler<CreatedGenericEvent<TEntity>> where TEntity : Entity
    {
        public virtual Task Handle(CreatedGenericEvent<TEntity> notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("CreatedGenericEventHandler.Handle");

            return Task.CompletedTask;
        }
    }



}
