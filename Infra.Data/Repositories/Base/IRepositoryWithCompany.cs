using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.Base;

namespace Infra.Data.Repositories.Base
{
    public interface IRepositoryWithCompany<TEntity> : IRepository<TEntity> where TEntity : EntityWithCompany
    {
        Task<IQueryable<TEntity>> GetAllAsync(string companyId);

        Task<TEntity> GetByIdAsync(string companyId, string id);
    }
}
