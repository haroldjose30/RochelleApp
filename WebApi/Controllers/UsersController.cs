using ApplicationBusiness.Services;
using Domain.Models;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class UsersController : BusinessController<User>
    {
        public UsersController(UserService _service) : base(_service)
        {

        }
    }

}
