using Domain.Generals.Companies.Commands;

namespace Domain.Generals.Companies.Validations
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
