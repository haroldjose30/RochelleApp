using Framework.Core.Models;

namespace Framework.Core.Commands
{
    public abstract class GenericCommand<TEntity> : Command where TEntity : Entity
    {
        public TEntity Entity { get; private set; }


        protected GenericCommand(TEntity entity)
        {
            this.Entity = entity;
        }

        public abstract override bool IsValid();
    }
}
