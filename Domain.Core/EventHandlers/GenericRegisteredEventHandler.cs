using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Events;
using Domain.Core.Models;
using MediatR;

namespace Domain.Core.EventHandlers
{
    public class GenericRegisteredEventHandler<TEntity> : INotificationHandler<GenericRegisteredEvent<TEntity>> where TEntity : Entity
    {
        public Task Handle(GenericRegisteredEvent<TEntity> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Console.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }

     
    }
}
