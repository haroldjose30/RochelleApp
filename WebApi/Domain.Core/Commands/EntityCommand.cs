using System;
using Domain.Core.Models;
using Newtonsoft.Json;

namespace Domain.Core.Commands
{
    public abstract class EntityCommand : Command
    {
        public string Id { get; protected set; }
        public string By { get; protected set; } 
    }


    public class GenericCommand<TEntity> : Command where TEntity : Entity
    {
        public TEntity entity  { get; set; }
     
        public GenericCommand(TEntity _entity)
        {
            entity = _entity;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
