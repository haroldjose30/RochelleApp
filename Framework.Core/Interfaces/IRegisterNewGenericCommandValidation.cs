using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{



    public interface IRegisterNewGenericCommandValidation<TEntity> where TEntity : Entity
    {
        ValidationResult Validate(RegisterNewGenericCommand<TEntity> registerNewGenericCommand);
    }


}