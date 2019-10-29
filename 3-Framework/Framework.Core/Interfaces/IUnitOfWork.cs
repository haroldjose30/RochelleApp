using System;
using System.Threading.Tasks;

namespace Framework.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
