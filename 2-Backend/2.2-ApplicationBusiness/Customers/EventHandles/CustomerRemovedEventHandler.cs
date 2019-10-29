using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Framework.Core.Events;
using MediatR;
namespace ApplicationBusiness.Customers.EventHandles
{
    public class CustomerRemovedEventHandler : INotificationHandler<GenericRemovedEvent<Customer>>
    {
        public Task Handle(GenericRemovedEvent<Customer> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }
}
