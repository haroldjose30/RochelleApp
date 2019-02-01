using Domain.Core.Commands;

namespace Domain.Generals.Companies.Commands
{
    public abstract class CompanyCommand : EntityCommand
    {
        public string CompanyName { get; protected set; }
        public string FantasyName { get; protected set; }
        public string CorporateNumber { get; protected set; }       
    }
}
