using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Identity;
using Infra.Data.Context;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public class UserGenericRepositoryEntity : GenericRepositoryEntityWithCompany<User>, IUserGenericRepositoryEntity
    {
        public UserGenericRepositoryEntity(DbContextGeneric context)
            : base(context)
        {
            Debug.WriteLine("User");
        }

        public async Task<User> GetByLogin(string login)
        {
            Expression<Func<User, bool>> filterBy = e => e.Login == login && e.Deleted == false;
            return await base.GetFirstOrDefault(filterBy);
        }
    }
}