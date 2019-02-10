using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals.Companies.Events;
using MediatR;

namespace Domain.Generals.Companies.EventHandles
{
    public class CompanyRegisteredEventHandler : INotificationHandler<CompanyRegisteredEvent>
    {
        public Task Handle(CompanyRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Console.WriteLine("CompanyRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }
}
