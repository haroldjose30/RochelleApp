using System;
using Domain.Generals.Companies.Commands;

namespace Domain.Generals.Companies.Validations
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
