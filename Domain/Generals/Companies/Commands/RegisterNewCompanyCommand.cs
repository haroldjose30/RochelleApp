using Domain.Generals.Companies.Validations;

namespace Domain.Generals.Companies.Commands
{
    public class RegisterNewCompanyCommand : CompanyCommand
    {
       public RegisterNewCompanyCommand(string By, string companyName, string fantasyName, string corporateNumber)
        {
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.CorporateNumber = corporateNumber;
            this.By = By;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCompanyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
