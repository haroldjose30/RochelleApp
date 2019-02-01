using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Framework.NetCore.Contexts
{
    public interface IDbContextGeneric : IDisposable
    {
         DbSet<TEntity> Set<TEntity>() where TEntity : class;
         Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
         EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}


