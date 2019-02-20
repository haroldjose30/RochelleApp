using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Interfaces
{
    public interface IUpdateGenericCommandValidation<TEntity> where TEntity : Entity
    {
        ValidationResult Validate(UpdateGenericCommand<TEntity> updateGenericCommand);
    }
}