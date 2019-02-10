using Domain.Generals.Companies.Validations;
using MediatR;

namespace Domain.Generals.Companies.Commands
{
    public class RegisterNewCompanyCommand : CompanyCommand
    {
       public RegisterNewCompanyCommand(string by, string companyName, string fantasyName, string corporateNumber)
        {
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.CorporateNumber = corporateNumber;
            this.By = by;
        }


        public RegisterNewCompanyCommand(Company company)
        {
          this.Id = company.Id;
          this.CompanyName = company.CompanyName;
          this.FantasyName = company.FantasyName;
          this.CorporateNumber = company.CorporateNumber;
          this.By = company.CreatedBy;
        }

        public override bool IsValid()
        {
             ValidationResult = new RegisterNewCompanyCommandValidation().Validate(this);
              return ValidationResult.IsValid;
        }
    }
}
