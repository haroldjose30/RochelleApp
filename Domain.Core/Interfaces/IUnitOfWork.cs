using System;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
