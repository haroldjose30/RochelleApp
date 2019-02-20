using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Framework.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {

        public Guid Id;

        private List<DomainNotification> domainNotifications;

        public DomainNotificationHandler()
        {
            Id = Guid.NewGuid();
            domainNotifications = new List<DomainNotification>();
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return domainNotifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            domainNotifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            domainNotifications.Add(message);
            return Task.CompletedTask;
        }
    }
}
