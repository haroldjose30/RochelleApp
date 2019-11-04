using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;

namespace Framework.Core.Validations
{
    public class DeleteGenericCommandValidation<TEntity> : GenericValidation<TEntity> , IDeleteGenericCommandValidation<TEntity> where TEntity : Entity, new()
    {
        public DeleteGenericCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }

        public ValidationResult Validate(DeleteGenericCommand<TEntity> deleteGenericCommand)
        {
            return base.Validate(deleteGenericCommand);
        }
    }
}
