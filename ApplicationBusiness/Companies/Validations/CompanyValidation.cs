using Domain.Generals;
using FluentValidation;
using Framework.Core.Validations;

namespace ApplicationBusiness.Companies.Validations
{
    public abstract class CompanyValidation : GenericValidation<Company>
    {
        protected void ValidateCompanyName()
        {
            RuleFor(a => a.entity.CompanyName)
               .NotEmpty()
               .WithMessage("Razão social deve ser informado!");
        }

        protected void ValidateFantasyName()
        {
            RuleFor(a => a.entity.FantasyName)
               .NotEmpty()
               .WithMessage("Nome da fantasia deve ser informado!");
        }

        protected void ValidateCorporateNumber()
        {
            RuleFor(a => a.entity.CorporateNumber)
             .NotEmpty()
             .WithMessage("Cpf/Cnpj deve ser informado!");
        }
    }
}