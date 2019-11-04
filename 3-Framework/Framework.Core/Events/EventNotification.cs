using System;

namespace Framework.Core.Events
{
    public abstract class EventNotification : MessageNotification
    {
        public DateTime Timestamp { get;}

        protected EventNotification()
        {
            Timestamp = DateTime.Now;
        }
    }
}
