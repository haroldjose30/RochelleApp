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
   public class UpdateGenericCommandHandler<TEntity> : CommandHandler, IRequestHandler<UpdateGenericCommand<TEntity>> where TEntity : Entity
    {
        IRepository<TEntity> repository;

        public UpdateGenericCommandHandler(IRepository<TEntity> _Repository,
                                                IUnitOfWork uow,
                                                IMediatorHandler _Bus) : base(uow, _Bus)
        {
            repository = _Repository;
        }



    public async Task<Unit> Handle(UpdateGenericCommand<TEntity> request, CancellationToken cancellationToken)
    {
        Debug.WriteLine("UpdateGenericCommand");



            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }


            repository.Update(request.entity);

            if (await CommitAsync())
            {
                Bus.PublishEvent(new GenericUpdatedEvent<TEntity>(request.entity));
            }

            return new Unit();
        }

       
    }
}
