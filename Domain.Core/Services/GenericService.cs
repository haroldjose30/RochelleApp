using System;
using System.Collections.Generic;
using Domain.Core.Commands;
using Domain.Core.Interfaces;
using Domain.Core.Models;

namespace ApplicationBusiness.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : Entity
    {

        private readonly IRepository<TEntity> _repository;
        private readonly IMediatorHandler Bus;

        public GenericService(IRepository<TEntity> repository, IMediatorHandler bus)
        {
            _repository = repository;
            Bus = bus;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(string id)
        {
            return _repository.GetById(id);
        }

        public TEntity Register(TEntity entity)
        {
            var oRegisterNewGenericCommand = new RegisterNewGenericCommand<TEntity>(entity);
            Bus.SendCommand(oRegisterNewGenericCommand);
            return null;
        }

        public TEntity Update(TEntity entity)
        {
            var oUpdateGenericCommand = new UpdateGenericCommand<TEntity>(entity);
            Bus.SendCommand(oUpdateGenericCommand);
            return null;
        }

        public bool Remove(string id, string removedBy)
        {
            var removeCommand = new RemoveGenericCommand<TEntity>(id, removedBy);
            Bus.SendCommand(removeCommand);
            return false;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
      
    }
}
