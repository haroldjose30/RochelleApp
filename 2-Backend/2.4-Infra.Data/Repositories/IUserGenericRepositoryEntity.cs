using System.Threading.Tasks;
using Domain.Identity;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public interface IUserGenericRepositoryEntity:  IGenericRepositoryEntityWithCompany<User> 
    {
        Task<User> GetByLogin(string login);
    }
}