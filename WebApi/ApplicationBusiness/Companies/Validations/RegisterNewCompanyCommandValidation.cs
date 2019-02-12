using ApplicationBusiness.Companies.Commands;

namespace ApplicationBusiness.Companies.Validations
{
    public class RegisterNewCompanyCommandValidation : CompanyValidation<RegisterNewCompanyCommand>
    {
        public RegisterNewCompanyCommandValidation()
        {
            ValidateCompanyName();
            ValidateFantasyName();
            ValidateCorporateNumber();
            ValidateBy();
        }
    }

}
