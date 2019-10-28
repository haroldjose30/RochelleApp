/*
using System.Linq;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Domain.Generals.Base;

namespace Infra.Data.Repositories.Base
{
    public interface IRepositoryWithCompany<TEntity> : IRepository<TEntity> where TEntity : EntityWithCompany
    {
        Task<IQueryable<TEntity>> GetAllAsync(string companyId);

        Task<TEntity> GetByIdAsync(string companyId, string id);
    }
}
*/
