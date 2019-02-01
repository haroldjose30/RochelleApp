using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Models;

namespace Domain.Core.Interfaces
{
    public interface IMediatorHandler
    {

        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<TEvent,TEntity>(TEvent @event) where TEvent : Event<TEntity> where TEntity:Entity;
        Task RaiseEvent<TEvent>(TEvent @event) where TEvent : Event;

    }
}
