using System;

namespace Domain.Core.Events
{
    public abstract class EventRequest : MessageRequest
    {
        public DateTime Timestamp { get; private set; }

        protected EventRequest()
        {
            Timestamp = DateTime.Now;
        }
    }

    public abstract class EventNotification : MessageNotification
    {
        public DateTime Timestamp { get; private set; }

        protected EventNotification()
        {
            Timestamp = DateTime.Now;
        }
    }
}
