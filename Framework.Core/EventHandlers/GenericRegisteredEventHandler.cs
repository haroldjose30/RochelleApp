using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.EventHandlers
{
    // public class GenericRegisteredEventHandler<TEntity> : INotificationHandler<GenericRegisteredEvent<TEntity>> where TEntity : Entity
    // {
    //     public Task Handle(GenericRegisteredEvent<TEntity> notification, CancellationToken cancellationToken)
    //     {
    //         // Send some greetings e-mail
    //         Console.WriteLine("GenericRegisteredEventHandler");

    //         return Task.CompletedTask;
    //     }
    // }



}
