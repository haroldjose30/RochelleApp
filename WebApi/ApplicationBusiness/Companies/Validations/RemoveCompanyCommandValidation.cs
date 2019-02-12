using ApplicationBusiness.Companies.Commands;

namespace ApplicationBusiness.Companies.Validations
{
    public class RemoveCompanyCommandValidation : CompanyValidation<RemoveCompanyCommand>
    {
        public RemoveCompanyCommandValidation()
        {
            ValidateId();
            ValidateBy();
        }
    }
}
