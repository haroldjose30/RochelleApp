using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Framework.Core.Events;
using MediatR;
namespace ApplicationBusiness.Customers.EventHandles
{

    public class CustomerUpdatedEventHandler : INotificationHandler<GenericUpdatedEvent<Customer>>
    {
        public Task Handle(GenericUpdatedEvent<Customer> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }

}
