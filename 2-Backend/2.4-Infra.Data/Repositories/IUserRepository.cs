using System.Threading.Tasks;
using Domain.Identity;
using Framework.Core.Interfaces;

namespace Infra.Data.Repositories
{
    public interface IUserRepository:  IRepository<User> 
    {
        Task<User> GetByLogin(string login);
    }
}