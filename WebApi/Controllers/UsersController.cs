using Domain.Identity;
using Framework.NetStd.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class UsersController : GenericController<User>
    {
        public UsersController(IMediator _mediator, IServiceGeneric<User> _service) : base(_mediator,_service)
        {

        }
    }

}
