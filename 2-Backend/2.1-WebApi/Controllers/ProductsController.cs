using Domain.Generals;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IGenericService<Product> service,
            INotificationHandler<DomainNotification> notifications) : base(service, notifications)
        {
        }
    }
}