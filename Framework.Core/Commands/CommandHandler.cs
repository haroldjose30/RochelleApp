using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace Framework.Core.Commands
{
    public class CommandHandler
    {
        protected readonly IUnitOfWork uow;
        protected readonly IMediatorHandler Bus;
        protected readonly DomainNotificationHandler _notifications;

        public CommandHandler(
                              IUnitOfWork _uow
                              ,IMediatorHandler _Bus
                              ,INotificationHandler<DomainNotification> notifications
                              )
        {
            uow = _uow;
            _notifications = (DomainNotificationHandler)notifications;
            Bus = _Bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                Bus.PublishEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public async Task<bool> CommitAsync()
        {
            if (_notifications.HasNotifications()) return false;
            if (await uow.CommitAsync()) return true;

            Bus.PublishEvent(new DomainNotification("Commit", "Tivemos um problemas durante a gravaçao dos dados."));
            return false;
        }
    }
}
