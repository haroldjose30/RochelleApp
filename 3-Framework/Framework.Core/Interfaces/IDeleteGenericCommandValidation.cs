using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{
    public interface IDeleteGenericCommandValidation<TEntity> where TEntity : Entity , new()
    {
        ValidationResult Validate(DeleteGenericCommand<TEntity> deleteGenericCommand);
    }
}