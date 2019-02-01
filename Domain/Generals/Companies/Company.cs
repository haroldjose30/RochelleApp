using Domain.Core.Models;
using Newtonsoft.Json;

namespace Domain.Generals
{
    public class Company:Entity
    {
        public string CompanyName { get; protected set; }
        public string FantasyName { get; protected set; }
        public string CorporateNumber { get; protected set; }

        public Company(string companyName, string fantasyName, string corporateNumber,string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            CorporateNumber = corporateNumber;
        }

        public void Update(string companyName, string fantasyName, string corporateNumber, string modifiedBy) 
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            CorporateNumber = corporateNumber;
            this.Update(modifiedBy);
        }


    }

}
