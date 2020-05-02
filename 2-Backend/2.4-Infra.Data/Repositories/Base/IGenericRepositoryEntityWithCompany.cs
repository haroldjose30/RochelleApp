
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base;
using Framework.Core.Interfaces;

namespace Infra.Data.Repositories.Base
{
    public interface IGenericRepositoryEntityWithCompany<TEntity> : IGenericRepositoryEntity<TEntity> where TEntity : EntityWithCompany
    {
        Task<IEnumerable<TEntity>> GetAll(Guid companyId);

        Task<TEntity> GetById(Guid companyId, Guid id);
    }
}
