using Domain.Generals;
using FluentValidation.Results;
using Framework.Core.Interfaces;

namespace ApplicationBusiness.Companies.Validations
{
    public class CreateCompanyCommandValidation : CompanyValidation, ICreateGenericCommandValidation<Company>
    {
        public CreateCompanyCommandValidation()
        {
            ValidateCompanyName();
            ValidateFantasyName();
            ValidateCorporateNumber();
            ValidateCreatedBy();
        }

        public ValidationResult Validate(Framework.Core.Commands.CreateGenericCommand<Company> createGenericCommand)
        {
            return base.Validate(createGenericCommand);
        }
    }
}
