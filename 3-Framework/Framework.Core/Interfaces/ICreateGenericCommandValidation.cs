using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{
    public interface ICreateGenericCommandValidation<TEntity> where TEntity : Entity
    {
        ValidationResult Validate(CreateGenericCommand<TEntity> createGenericCommand);
    }


}