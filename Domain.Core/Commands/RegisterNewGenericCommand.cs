using System.Diagnostics;
using Domain.Core.Models;
using Domain.Core.Validations;

namespace Domain.Core.Commands
{
    public class RegisterNewGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        public RegisterNewGenericCommand(TEntity _entity) : base(_entity)
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewGenericCommandValidation<TEntity>().Validate(this);
            return ValidationResult.IsValid;
        }

    }




}
