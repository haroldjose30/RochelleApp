using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{
    public interface IRemoveGenericCommandValidation<TEntity> where TEntity : Entity
    {
        ValidationResult Validate(RemoveGenericCommand<TEntity> removeGenericCommand);
    }
}