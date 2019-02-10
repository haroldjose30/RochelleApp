using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Models;
using MediatR;

namespace Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<TComand>(TComand command) where TComand : Command;
        Task RaiseEvent<T>(T @event) where T : EventNotification;
    }
}
