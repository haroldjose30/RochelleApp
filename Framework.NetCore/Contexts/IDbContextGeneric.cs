using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Framework.NetCore.Contexts
{
    public interface IDbContextGeneric : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));


    }
}


