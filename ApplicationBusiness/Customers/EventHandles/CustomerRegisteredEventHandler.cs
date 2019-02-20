using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Framework.Core.Events;
using MediatR;

namespace ApplicationBusiness.Customers.EventHandles
{
    public class CustomerRegisteredEventHandler : INotificationHandler<GenericRegisteredEvent<Customer>>
    {
        public Task Handle(GenericRegisteredEvent<Customer> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }
}
