using Domain.Generals;
using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;

namespace ApplicationBusiness.Companies.Validations
{
    
    public class UpdateCompanyCommandValidation : CompanyValidation,IUpdateGenericCommandValidation<Company>
    {
        public UpdateCompanyCommandValidation()
        {
            ValidateId();
            ValidateCompanyName();
            ValidateFantasyName();
            ValidateCorporateNumber();
            ValidateModifiedBy();
        }

        public ValidationResult Validate(UpdateGenericCommand<Company> updateGenericCommand)
        {
            return base.Validate(updateGenericCommand);
        }
    }
}
