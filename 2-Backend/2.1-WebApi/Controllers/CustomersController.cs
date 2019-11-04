using Domain.Generals;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IGenericService<Customer> service, INotificationHandler<DomainNotification> notifications) : base(service, notifications)
        {
            
        }
    }
}