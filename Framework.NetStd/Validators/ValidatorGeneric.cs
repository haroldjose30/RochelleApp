using FluentValidation;
using Framework.NetStd.Models;

namespace Framework.NetStd.Validators
{
    public abstract class ValidatorGeneric<TEntity> : AbstractValidator<TEntity>, IValidatorGeneric<TEntity> where TEntity : Entity
    {
        protected ValidatorGeneric()
        {
            ValidateDeleted();
        }

        protected void ValidateDeleted()
        {
            RuleFor(c => c.Deleted)
                .Equal(true).WithMessage("Register Deleted!");
        }
    }
}
