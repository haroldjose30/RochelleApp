namespace ApplicationBusiness.Companies.Validations
{
    public class RemoveCompanyCommandValidation : CompanyValidation
    {
        public RemoveCompanyCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }
    }
}
