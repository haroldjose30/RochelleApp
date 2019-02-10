using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Events;
using Domain.Core.Models;
using MediatR;

namespace Domain.Core.EventHandlers
{
    public class GenericRemovedEventHandler<TEntity> : INotificationHandler<GenericRemovedEvent<TEntity>> where TEntity : Entity
    {
        public Task Handle(GenericRemovedEvent<TEntity> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Console.WriteLine("GenericRemovedEventHandler");

            return Task.CompletedTask;
        }
    }
}
