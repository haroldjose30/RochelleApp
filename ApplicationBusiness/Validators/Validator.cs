using System;
using Domain.Models.Base;
using FluentValidation;

namespace ApplicationBusiness.Validators
{
    public abstract class Validator<TEntity> : AbstractValidator<TEntity> where TEntity : Entity
    {
        public Validator()
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
