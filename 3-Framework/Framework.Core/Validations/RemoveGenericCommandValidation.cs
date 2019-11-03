using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;

namespace Framework.Core.Validations
{
    public class RemoveGenericCommandValidation<TEntity> : GenericValidation<TEntity> , IRemoveGenericCommandValidation<TEntity> where TEntity : Entity, new()
    {
        public RemoveGenericCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }

        public ValidationResult Validate(RemoveGenericCommand<TEntity> removeGenericCommand)
        {
            return base.Validate(removeGenericCommand);
        }
    }
}
