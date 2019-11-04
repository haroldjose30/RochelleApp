using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Events;

namespace Framework.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<TCommand>(TCommand command) where TCommand : Command;
        Task PublishEvent<T>(T @event) where T : EventNotification;
    }
}
