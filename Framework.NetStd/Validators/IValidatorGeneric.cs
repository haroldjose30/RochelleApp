using FluentValidation;
using Framework.NetStd.Models;

namespace Framework.NetStd.Validators
{
    public interface IValidatorGeneric<TEntity>: IValidator<TEntity>  where TEntity : Entity
    {

    }
}
