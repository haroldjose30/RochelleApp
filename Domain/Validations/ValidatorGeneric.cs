using Domain.Core.Models;
using FluentValidation;


namespace ApplicationBusiness.Validators
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
