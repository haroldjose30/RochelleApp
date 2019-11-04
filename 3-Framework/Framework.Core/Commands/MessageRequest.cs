using MediatR;

namespace Framework.Core.Commands
{
    public abstract class MessageRequest : IRequest
    {
        public string MessageType { get; }

        protected MessageRequest()
        {
            MessageType = GetType().Name;
        }
    }
}