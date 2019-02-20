using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.CommandHandlers;
using Framework.Core.Events;
using Framework.Core.Interfaces;
using Domain.Generals;
using MediatR;
using Framework.Core.Notifications;

namespace ApplicationBusiness.Products.CommandHandlers
{
    public class RegisterNewProductCommandHandler : RegisterNewGenericCommandHandler<Product>
   {
      

        public RegisterNewProductCommandHandler(IRepository<Product> _Repository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_Repository, _uow, _Bus, notifications)
        {
        }
    }

    public class UpdateProductCommandHandler : UpdateGenericCommandHandler<Product>
    {


        public UpdateProductCommandHandler(IRepository<Product> _Repository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_Repository, _uow, _Bus, notifications)
        {
        }
    }

    public class RemoveProductCommandHandler : RemoveGenericCommandHandler<Product>
    {
       

        public RemoveProductCommandHandler(IRepository<Product> _Repository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_Repository, _uow, _Bus, notifications)
        {
        }
    }

}



namespace ApplicationBusiness.Products.EventHandles
{
    public class ProductRegisteredEventHandler : INotificationHandler<GenericRegisteredEvent<Product>>
    {
        public Task Handle(GenericRegisteredEvent<Product> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }



    public class ProductRemovedEventHandler : INotificationHandler<GenericRemovedEvent<Product>>
    {
        public Task Handle(GenericRemovedEvent<Product> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }




    public class ProductUpdatedEventHandler : INotificationHandler<GenericUpdatedEvent<Product>>
    {
        public Task Handle(GenericUpdatedEvent<Product> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }
}
