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
    public class RegisterNewGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<RegisterNewGenericCommand<TEntity>> where TEntity : Entity
    {
        IRepository<TEntity> repository;
        public RegisterNewGenericCommandHandler(IRepository<TEntity> _Repository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_uow, _Bus, notifications)
        {
            repository = _Repository;
        }

        public async Task<Unit> Handle(RegisterNewGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("RegisterNewGenericCommand");

            //execute action to mark as created register
            request.entity.Create(request.entity.Id, request.entity.CreatedBy, request.entity.CreatedDate);

            //verify if entity was valid
            request.ValidationResult = request.entity.ValidationResult;


            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }

            var entityRegistered = repository.Add(request.entity);


            if (await CommitAsync())
            {
                Bus.PublishEvent(new GenericRegisteredEvent<TEntity>(entityRegistered));
            }

            return new Unit();
        }

    }

   



}
