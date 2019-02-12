using Domain.Core.Commands;
using Domain.Core.Models;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class GenericValidation<TEntity> : AbstractValidator<GenericCommand<TEntity>>  where TEntity:Entity
    {
        protected void ValidateId()
        {
            RuleFor(c => c.entity.Id)
                .NotEqual(string.Empty)
                .WithMessage("Id deve ser informado");
        }
       
        protected void ValidateCreatedBy()
        {
            RuleFor(c => c.entity.CreatedBy)
             .NotEmpty()
             .WithMessage("Usuário não informado!");
        }

        protected void ValidateModifiedBy()
        {
            RuleFor(c => c.entity.ModifiedBy)
             .NotEmpty()
             .WithMessage("Usuário não informado!");
        }

    }


}



