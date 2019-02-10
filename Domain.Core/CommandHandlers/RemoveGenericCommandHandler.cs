using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Interfaces;
using Domain.Core.Models;
using MediatR;

namespace Domain.Core.CommandHandlers
{
   public class RemoveGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<RemoveGenericCommand<TEntity>> where TEntity : Entity
    {
        IRepository<TEntity> repository;

        public RemoveGenericCommandHandler(IRepository<TEntity> _Repository,
                                                IUnitOfWork uow,
                                                IMediatorHandler _Bus) : base(uow, _Bus)
        {
            repository = _Repository;
        }

        public async Task<Unit> Handle(RemoveGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("RemoveCompanyCommand");


            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }

            repository.Remove(request.Id);

            if (await CommitAsync())
            {
                Bus.RaiseEvent(new GenericRemovedEvent<TEntity>(request.entity));
            }

            return new Unit();
        }

    }
}
