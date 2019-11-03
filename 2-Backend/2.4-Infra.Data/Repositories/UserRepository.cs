using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Identity;
using Infra.Data.Context;
using Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContextGeneric context)
            : base(context)
        {
            Debug.WriteLine("User");
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _dbSet.Where(u => u.Login == login).FirstOrDefaultAsync();
        }
    }
}