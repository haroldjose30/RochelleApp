using System.Linq;
using System.Threading.Tasks;
using Domain.Generals.Base;
using Framework.NetStd.Repositories;

namespace Infra.Data.Repositories.Base
{
    public interface IRepositoryWithCompany<TEntity> : IRepositoryGeneric<TEntity> where TEntity : EntityWithCompany
    {
        Task<IQueryable<TEntity>> GetAllAsync(string companyId);

        Task<TEntity> GetByIdAsync(string companyId, string id);
    }
}
