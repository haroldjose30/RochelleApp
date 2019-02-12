using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationBusiness.Companies.Events;
using MediatR;

namespace ApplicationBusiness.Companies.EventHandles
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
