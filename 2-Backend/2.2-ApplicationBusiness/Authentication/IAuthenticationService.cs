using System.Threading.Tasks;
using Domain.Identity;

namespace ApplicationBusiness.Authentication
{
    public interface IAuthenticationService
    {
        Task<User> Login(string login,string password);
    }
}