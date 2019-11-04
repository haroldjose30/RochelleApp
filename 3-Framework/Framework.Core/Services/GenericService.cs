using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;

namespace Framework.Core.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : Entity, new()
    {

        private readonly IGenericRepository<TEntity> genericRepository;
        private readonly IMediatorHandler _bus;
        private readonly IServiceProvider _serviceProvider;

        public GenericService(IGenericRepository<TEntity> genericRepository, 
                              IMediatorHandler bus,
                              IServiceProvider serviceProvider)
        {
            this.genericRepository = genericRepository;
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        public virtual async Task<IEnumerable<TEntity>>  GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await genericRepository.GetById(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var oRegisterNewGenericCommand = new CreateGenericCommand<TEntity>(entity, _serviceProvider);
            await _bus.SendCommand(oRegisterNewGenericCommand);
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var oUpdateGenericCommand = new UpdateGenericCommand<TEntity>(entity, _serviceProvider);
            await _bus.SendCommand(oUpdateGenericCommand);
            return entity;
        }

        public async Task<bool>  Delete(Guid id, string removedBy)
        {
            var removeCommand = new DeleteGenericCommand<TEntity>(id, removedBy, _serviceProvider);
            await _bus.SendCommand(removeCommand);
            return false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       
    }




}
