using MediatR;

namespace Framework.Core.Events
{
    public abstract class MessageNotification : INotification
    {
        public string MessageType { get; }

        protected MessageNotification()
        {
            MessageType = GetType().Name;
        }
    }
}
