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
   public class DeleteGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<DeleteGenericCommand<TEntity>> where TEntity : Entity, new()
    {
        private readonly IGenericRepository<TEntity> genericRepository;

        public DeleteGenericCommandHandler(IGenericRepository<TEntity> genericRepository,IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.genericRepository = genericRepository;
        }

        public virtual async Task<Unit> Handle(DeleteGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("DeleteGenericCommandHandler.Handle");

            await genericRepository.Delete(request.Entity.Id, request.Entity.ModifiedBy);

            if (await CommitAsync())
            {
                await _bus.PublishEvent(new DeletedGenericEvent<TEntity>(request.Entity));
            }

            return new Unit();
        }

    }
}
