using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Events;
using Framework.Core.Interfaces;
using MediatR;

namespace Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        //private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator)
        {
            //_eventStore = eventStore;
            _mediator = mediator;
        }

        public Task PublishEvent<T>(T @event) where T : EventNotification
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<TComand>(TComand command) where TComand : Command
        {
            return _mediator.Send(command);
        }

    }
}
