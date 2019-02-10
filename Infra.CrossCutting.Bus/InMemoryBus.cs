using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Interfaces;
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

        public Task RaiseEvent<T>(T @event) where T : EventNotification
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<TComand>(TComand command) where TComand : Command
        {
            return _mediator.Send(command);
        }

    }
}
