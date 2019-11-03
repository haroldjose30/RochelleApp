using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;

namespace Framework.Core.Validations
{
    public class UpdateGenericCommandValidation<TEntity> : GenericValidation<TEntity>, IUpdateGenericCommandValidation<TEntity> where TEntity : Entity
    {
        public UpdateGenericCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }

        public ValidationResult Validate(UpdateGenericCommand<TEntity> updateGenericCommand)
        {
            return base.Validate(updateGenericCommand);
        }
    }
}
