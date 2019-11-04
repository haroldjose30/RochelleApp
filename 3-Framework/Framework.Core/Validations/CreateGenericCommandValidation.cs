using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;

namespace Framework.Core.Validations
{
    public class CreateGenericCommandValidation<TEntity> : GenericValidation<TEntity>, ICreateGenericCommandValidation<TEntity> where TEntity : Entity
    {
        public CreateGenericCommandValidation()
        {
            ValidateId();
            ValidateCreatedBy();
        }

        public ValidationResult Validate(CreateGenericCommand<TEntity> createGenericCommand)
        {
            return base.Validate(createGenericCommand);
        }
    }

}
