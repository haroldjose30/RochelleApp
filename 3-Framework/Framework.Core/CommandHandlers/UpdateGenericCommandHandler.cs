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
   public class UpdateGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<UpdateGenericCommand<TEntity>> where TEntity : Entity
    {
        private readonly IGenericRepositoryEntity<TEntity> genericRepositoryEntity;

        public UpdateGenericCommandHandler(IGenericRepositoryEntity<TEntity> genericRepositoryEntity,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow,
            bus,
            notifications)
        {
            this.genericRepositoryEntity = genericRepositoryEntity;
        }

        public virtual async Task<Unit> Handle(UpdateGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("UpdateGenericCommandHandler.Handle");

            //execute action to mark as created register
            request.Entity.Update(request.Entity.ModifiedBy);

            //verify if entity was valid
            request.ValidationResult = request.Entity.GetValidationResult();

            await genericRepositoryEntity.Update(request.Entity);

            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }


            await genericRepositoryEntity.Update(request.Entity);

            if (await CommitAsync())
            {
                await _bus.PublishEvent(new UpdatedGenericEvent<TEntity>(request.Entity));
            }

            return new Unit();
        }

       
    }
}
