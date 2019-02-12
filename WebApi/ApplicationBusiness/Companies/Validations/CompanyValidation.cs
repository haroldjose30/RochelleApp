using ApplicationBusiness.Companies.Commands;
using FluentValidation;

namespace ApplicationBusiness.Companies.Validations
{
    public abstract class CompanyValidation<T> : AbstractValidator<T> where T : CompanyCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(string.Empty)
                .WithMessage("Id deve ser informado");
        }

        protected void ValidateCompanyName()
        {
            RuleFor(a => a.CompanyName)
               .NotEmpty()
               .WithMessage("Razão social deve ser informado!");
        }

        protected void ValidateFantasyName()
        {
            RuleFor(a => a.FantasyName)
               .NotEmpty()
               .WithMessage("Nome da fantasia deve ser informado!");
        }

        protected void ValidateCorporateNumber()
        {
            RuleFor(a => a.CorporateNumber)
             .NotEmpty()
             .WithMessage("Cpf/Cnpj deve ser informado!");
        }

        protected void ValidateBy()
        {
            RuleFor(c => c.By)
             .NotEmpty()
             .WithMessage("Usuário não informado!");
        }

    }
}