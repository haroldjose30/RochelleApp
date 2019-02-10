using Domain.Core.Models;
using Domain.Core.Validations;

namespace Domain.Core.Commands
{
    public class UpdateGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        public UpdateGenericCommand(TEntity _entity) : base(_entity)
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateGenericCommandValidation<TEntity>().Validate(this);
            return ValidationResult.IsValid;

        }

    }
}
