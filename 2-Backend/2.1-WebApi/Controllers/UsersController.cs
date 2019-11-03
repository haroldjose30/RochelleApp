using Domain.Identity;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class UsersController : GenericController<User>
    {
        public UsersController(IGenericService<User> service, INotificationHandler<DomainNotification> notifications) : base(service, notifications)
        {
            
        }
    }
}