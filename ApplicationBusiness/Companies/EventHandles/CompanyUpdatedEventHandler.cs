using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals.Companies.Events;
using MediatR;

namespace Domain.Generals.Companies.EventHandles
{

    public class CompanyUpdatedEventHandler : INotificationHandler<CompanyUpdatedEvent>
    {
        public Task Handle(CompanyUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Console.WriteLine("CompanyUpdatedEventHandler");

            return Task.CompletedTask;
        }
    }
}
