using Domain.Core.Models;
using FluentValidation;

namespace Framework.NetStd.Validators
{
    public interface IValidatorGeneric<TEntity>: IValidator<TEntity>  where TEntity : Entity
    {

    }
}
