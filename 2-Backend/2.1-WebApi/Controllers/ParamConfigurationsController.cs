using Domain.Generals;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class ParamConfigurationsController : GenericController<ParamConfiguration>
    {
        public ParamConfigurationsController(IGenericService<ParamConfiguration> service,
            INotificationHandler<DomainNotification> notifications) : base(service, notifications)
        {
        }

    }
}