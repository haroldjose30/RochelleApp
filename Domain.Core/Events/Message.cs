using System;
using MediatR;

namespace Domain.Core.Events
{
    public abstract class Message : INotification //IRequest
    {
        public string MessageType { get; protected set; }
        public string AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
