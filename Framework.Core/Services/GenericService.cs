using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : Entity
    {

        private readonly IRepository<TEntity> _repository;
        private readonly IMediatorHandler Bus;
        private readonly IMediator mediator;
        private readonly IServiceProvider serviceProvider;

        public GenericService(IRepository<TEntity> repository, 
                              IMediatorHandler _Bus,
                              IMediator _mediator,
                              IServiceProvider _serviceProvider)
        {
            _repository = repository;
            Bus = _Bus;
            mediator = _mediator;
            serviceProvider = _serviceProvider;
        }

        public async Task<IEnumerable<TEntity>>  GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<TEntity> GetById(string id)
        {
            return _repository.GetById(id);
        }

        public async Task<TEntity> RegisterAsync(TEntity entity)
        {
            var oRegisterNewGenericCommand = new RegisterNewGenericCommand<TEntity>(entity, serviceProvider);
            await Bus.SendCommand(oRegisterNewGenericCommand);
            return entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var oUpdateGenericCommand = new UpdateGenericCommand<TEntity>(entity, serviceProvider);
            await Bus.SendCommand(oUpdateGenericCommand);
            return entity;
        }

        public async Task<bool>  RemoveAsync(string id, string removedBy)
        {
            var removeCommand = new RemoveGenericCommand<TEntity>(id, removedBy, serviceProvider);
            await Bus.SendCommand(removeCommand);
            return false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       
    }




}
