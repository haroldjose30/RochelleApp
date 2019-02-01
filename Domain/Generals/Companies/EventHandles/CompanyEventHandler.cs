using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals.Companies.Events;
using MediatR;

namespace Domain.Generals.Companies.EventHandles
{
    public class CompanyEventHandler :
       INotificationHandler<CompanyRegisteredEvent>,
       INotificationHandler<CompanyUpdatedEvent>,
       INotificationHandler<CompanyRemovedEvent>
    {
        public Task Handle(CompanyUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CompanyRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CompanyRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
