using Domain.Generals;
using Domain.Identity;
using Framework.NetStd.Services;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class UsersController : GenericController<User>
    {
        public UsersController(IServiceGeneric<User> _service) : base(_service)
        {

        }
    }

}
