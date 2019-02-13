using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Domain.Core.CommandHandlers;
using Domain.Core.EventHandlers;
using Domain.Core.Interfaces;
using Domain.Generals;
using Domain.Core.Events;
using MediatR;

namespace ApplicationBusiness.Companies.Services
{
    public class RegisterNewCustomerCommandHandler : RegisterNewGenericCommandHandler<Customer>
   {
       public RegisterNewCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork uow, IMediatorHandler _Bus) : base(_Repository, uow, _Bus)
       {
         
       }
   }

    public class UpdateCustomerCommandHandler : UpdateGenericCommandHandler<Customer>
    {
        public UpdateCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork uow, IMediatorHandler _Bus) : base(_Repository, uow, _Bus)
        {
        }
    }

    public class RemoveCustomerCommandHandler : RemoveGenericCommandHandler<Customer>
    {
        public RemoveCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork uow, IMediatorHandler _Bus) : base(_Repository, uow, _Bus)
        {
        }
   }

    public class CustomerRegisteredEventHandler : INotificationHandler<GenericRegisteredEvent<Customer>>
    {
        public Task Handle(GenericRegisteredEvent<Customer> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }



    public class CustomerRemovedEventHandler : INotificationHandler<GenericRemovedEvent<Customer>>
    {
        public Task Handle(GenericRemovedEvent<Customer> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }




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
