using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using MediatR;

namespace Framework.Core.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : Entity, new()
    {

        private readonly IRepository<TEntity> _repository;
        private readonly IMediatorHandler _bus;
        private readonly IMediator mediator;
        private readonly IServiceProvider _serviceProvider;

        public GenericService(IRepository<TEntity> repository, 
                              IMediatorHandler bus,
                              IMediator mediator,
                              IServiceProvider serviceProvider)
        {
            _repository = repository;
            _bus = bus;
            this.mediator = mediator;
            this._serviceProvider = serviceProvider;
        }

        public virtual async Task<IEnumerable<TEntity>>  GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task<TEntity> RegisterAsync(TEntity entity)
        {
            var oRegisterNewGenericCommand = new RegisterNewGenericCommand<TEntity>(entity, _serviceProvider);
            await _bus.SendCommand(oRegisterNewGenericCommand);
            return entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var oUpdateGenericCommand = new UpdateGenericCommand<TEntity>(entity, _serviceProvider);
            await _bus.SendCommand(oUpdateGenericCommand);
            return entity;
        }

        public async Task<bool>  RemoveAsync(string id, string removedBy)
        {
            var removeCommand = new RemoveGenericCommand<TEntity>(id, removedBy, _serviceProvider);
            await _bus.SendCommand(removeCommand);
            return false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       
    }




}
