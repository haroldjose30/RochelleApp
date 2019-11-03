using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Events;

namespace Framework.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<TComand>(TComand command) where TComand : Command;
        Task PublishEvent<T>(T @event) where T : EventNotification;
    }
}
