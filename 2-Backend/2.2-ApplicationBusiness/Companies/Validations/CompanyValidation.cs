using Domain.Generals;
using FluentValidation;
using Framework.Core.Validations;

namespace ApplicationBusiness.Companies.Validations
{
    public abstract class CompanyValidation : GenericValidation<Company>
    {
        protected void ValidateCompanyName()
        {
            RuleFor(a =>  a.Entity.CompanyName)
               .NotEmpty()
               .WithMessage("Razão social deve ser informado!");
        }

        protected void ValidateFantasyName()
        {
            RuleFor(a => a.Entity.FantasyName)
               .NotEmpty()
               .WithMessage("Nome da fantasia deve ser informado!");
        }

        protected void ValidateCorporateNumber()
        {
            RuleFor(a => a.Entity.CorporateNumber)
             .NotEmpty()
             .WithMessage("Cpf/Cnpj deve ser informado!");
        }
    }
}