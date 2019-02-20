using Domain.Generals;
using FluentValidation.Results;
using Framework.Core.Interfaces;

namespace ApplicationBusiness.Companies.Validations
{
    public class RegisterNewCompanyCommandValidation : CompanyValidation, IRegisterNewGenericCommandValidation<Company>
    {
        public RegisterNewCompanyCommandValidation()
        {
            ValidateCompanyName();
            ValidateFantasyName();
            ValidateCorporateNumber();
            ValidateCreatedBy();
        }

        public ValidationResult Validate(Framework.Core.Commands.RegisterNewGenericCommand<Company> registerNewGenericCommand)
        {
            return base.Validate(registerNewGenericCommand);
        }
    }
}
