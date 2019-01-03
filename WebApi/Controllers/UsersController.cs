using Domain.Generals;
using Framework.NetStd.Services;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class UsersController : BusinessController<User>
    {
        public UsersController(IServiceGeneric<User> _service) : base(_service)
        {

        }
    }

}
