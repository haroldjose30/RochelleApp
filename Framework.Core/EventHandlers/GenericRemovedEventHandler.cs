using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.EventHandlers
{
    // public class GenericRemovedEventHandler<TEntity> : INotificationHandler<GenericRemovedEvent<TEntity>> where TEntity : Entity
    // {
    //     public Task Handle(GenericRemovedEvent<TEntity> notification, CancellationToken cancellationToken)
    //     {
    //         // Send some greetings e-mail
    //         Console.WriteLine("GenericRemovedEventHandler");

    //         return Task.CompletedTask;
    //     }
    // }
}
