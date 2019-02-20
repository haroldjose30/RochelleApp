using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Events;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Notifications;
using MediatR;

namespace Framework.Core.CommandHandlers
{
   public class RemoveGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<RemoveGenericCommand<TEntity>> where TEntity : Entity
    {
        IRepository<TEntity> repository;

        public RemoveGenericCommandHandler(IRepository<TEntity> _Repository,IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_uow, _Bus, notifications)
        {
            repository = _Repository;
        }

        public async Task<Unit> Handle(RemoveGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("RemoveGenericCommand");


            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }

            repository.Remove(request.Id);

            if (await CommitAsync())
            {
                Bus.PublishEvent(new GenericRemovedEvent<TEntity>(request.entity));
            }

            return new Unit();
        }

    }
}
