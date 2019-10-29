namespace ApplicationBusiness.Companies.Validations
{
    public class UpdateCompanyCommandValidation : CompanyValidation
    {
        public UpdateCompanyCommandValidation()
        {
            ValidateId();
            ValidateCompanyName();
            ValidateFantasyName();
            ValidateCorporateNumber();
            ValidateModifiedBy();
        }
    }
}
