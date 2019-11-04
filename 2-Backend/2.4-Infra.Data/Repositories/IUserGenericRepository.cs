using System.Threading.Tasks;
using Domain.Identity;
using Framework.Core.Interfaces;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public interface IUserGenericRepository:  IGenericRepositoryWithCompany<User> 
    {
        Task<User> GetByLogin(string login);
    }
}