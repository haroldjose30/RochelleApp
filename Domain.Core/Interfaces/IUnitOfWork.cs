using System;
namespace Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
