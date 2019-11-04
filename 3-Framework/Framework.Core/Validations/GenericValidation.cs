using FluentValidation;
using Framework.Core.Commands;
using Framework.Core.Models;

namespace Framework.Core.Validations
{
    public abstract class GenericValidation<TEntity> : AbstractValidator<GenericCommand<TEntity>>  where TEntity:Entity
    {

        protected void ValidateId()
        {
            RuleFor(c => c.Entity.Id)
                .NotEmpty()
                .WithMessage("Id deve ser informado");
        }
       
        protected void ValidateCreatedBy()
        {
            RuleFor(c => c.Entity.CreatedBy)
             .NotEmpty()
             .WithMessage("Usuário não informado!");
        }

        protected void ValidateModifiedBy()
        {
            RuleFor(c => c.Entity.ModifiedBy)
             .NotEmpty()
             .WithMessage("Usuário não informado!");
        }

       
    }


}



