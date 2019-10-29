using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Models;

namespace Framework.Core.Validations
{
    public class RegisterNewGenericCommandValidation<TEntity> : GenericValidation<TEntity>, IRegisterNewGenericCommandValidation<TEntity> where TEntity : Entity
    {
        public RegisterNewGenericCommandValidation()
        {
            ValidateId();
            ValidateCreatedBy();
        }

        public ValidationResult Validate(RegisterNewGenericCommand<TEntity> registerNewGenericCommand)
        {
            return base.Validate(registerNewGenericCommand);
        }
    }

}
