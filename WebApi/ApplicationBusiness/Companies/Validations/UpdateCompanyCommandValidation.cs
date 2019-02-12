using ApplicationBusiness.Companies.Commands;

namespace ApplicationBusiness.Companies.Validations
{
    public class UpdateCompanyCommandValidation : CompanyValidation<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidation()
        {
            ValidateId();
            ValidateCompanyName();
            ValidateFantasyName();
            ValidateCorporateNumber();
            ValidateBy();
        }
    }
}
