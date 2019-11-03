using Domain.Generals;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class CompaniesController : GenericController<Company>
    {
        public CompaniesController(IGenericService<Company> service, INotificationHandler<DomainNotification> notifications) : base(service, notifications)
        {
            
        }
    }
}