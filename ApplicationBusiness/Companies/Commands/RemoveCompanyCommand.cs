using Domain.Generals.Companies.Validations;

namespace Domain.Generals.Companies.Commands
{
    public class RemoveCompanyCommand : CompanyCommand
    {
        public RemoveCompanyCommand(string id,string removedBy)
        {
            Id = id;
            By = removedBy;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCompanyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
