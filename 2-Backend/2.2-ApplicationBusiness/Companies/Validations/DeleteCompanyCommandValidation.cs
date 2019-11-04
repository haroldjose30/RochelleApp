using Domain.Generals;
using FluentValidation.Results;
using Framework.Core.Commands;
using Framework.Core.Interfaces;

namespace ApplicationBusiness.Companies.Validations
{
    public class DeleteCompanyCommandValidation : CompanyValidation,IDeleteGenericCommandValidation<Company>
    {
        public DeleteCompanyCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }

        public ValidationResult Validate(DeleteGenericCommand<Company> deleteGenericCommand)
        {
            return base.Validate(deleteGenericCommand);
        }
    }
}
