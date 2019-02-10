using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Interfaces;
using Domain.Core.Models;
using MediatR;

namespace Domain.Core.CommandHandlers
{
    public class RegisterNewGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<RegisterNewGenericCommand<TEntity>> where TEntity : Entity
    {
        IRepository<TEntity> repository;

        public RegisterNewGenericCommandHandler(IRepository<TEntity> _Repository,
                                                IUnitOfWork uow,
                                                IMediatorHandler _Bus) : base(uow, _Bus)
        {
            repository = _Repository;
        }

        public async Task<Unit> Handle(RegisterNewGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {

            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }

            var entityRegistered = repository.Add(request.entity);


            if (await CommitAsync())
            {
                Bus.RaiseEvent(new GenericRegisteredEvent<TEntity>(entityRegistered));
            }

            return new Unit();
        }

    }

   



}
