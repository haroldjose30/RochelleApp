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
    public class CreateGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<CreateGenericCommand<TEntity>> where TEntity : Entity
    {
        private readonly IGenericRepository<TEntity> genericRepository;
        public CreateGenericCommandHandler(IGenericRepository<TEntity> genericRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.genericRepository = genericRepository;
        }

        public virtual async Task<Unit> Handle(CreateGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("CreateGenericCommandHandler.Handle");

            //execute action to mark as created register
            request.Entity.Create( request.Entity.CreatedBy,request.Entity.Id);

            //verify if entity was valid
            request.ValidationResult = request.Entity.GetValidationResult();


            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }

            var entityRegistered = await genericRepository.Insert(request.Entity);


            if (await CommitAsync())
            {
                await _bus.PublishEvent(new CreatedGenericEvent<TEntity>(entityRegistered));
            }

            return new Unit();
        }

    }

   



}
