using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace Framework.Core.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(
                              IUnitOfWork uow
                              ,IMediatorHandler bus
                              ,INotificationHandler<DomainNotification> notifications
                              )
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.PublishEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        protected async Task<bool> CommitAsync()
        {
            if (_notifications.HasNotifications()) return false;
            if (await _uow.CommitAsync()) return true;

            await _bus.PublishEvent(new DomainNotification("Commit", "Tivemos um problemas durante a gravaçao dos dados."));
            return false;
        }
    }
}
