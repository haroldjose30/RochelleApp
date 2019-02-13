using Domain.Core.Models;
using FluentValidation;

namespace ApplicationBusiness.Validators
{
    public interface IValidatorGeneric<TEntity>: IValidator<TEntity>  where TEntity : Entity
    {

    }
}
