using Domain.Generals.Companies.Commands;

namespace Domain.Generals.Companies.Validations
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
