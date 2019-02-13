using System;
using MediatR;

namespace Domain.Core.Events
{
    public abstract class MessageRequest : IRequest
    {
        public string MessageType { get; protected set; }
        public string AggregateId { get; protected set; }

        protected MessageRequest()
        {
            MessageType = GetType().Name;
        }
    }



    public abstract class MessageNotification : INotification
    {
        public string MessageType { get; protected set; }
        public string AggregateId { get; protected set; }

        protected MessageNotification()
        {
            MessageType = GetType().Name;
        }
    }
}
