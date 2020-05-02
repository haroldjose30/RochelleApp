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

        public InMemoryBus(IMediator mediator) => _mediator = mediator;

        public Task PublishEvent<T>(T @event) where T : EventNotification
            => _mediator.Publish(@event);

        public Task SendCommand<TCommand>(TCommand command) where TCommand : Command
            => _mediator.Send(command);

    }
}
