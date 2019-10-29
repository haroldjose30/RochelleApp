using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{
    public interface IRemoveGenericCommandValidation<TEntity> where TEntity : Entity , new()
    {
        ValidationResult Validate(RemoveGenericCommand<TEntity> removeGenericCommand);
    }
}