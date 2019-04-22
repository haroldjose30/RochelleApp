using Framework.Core.Models;
using Newtonsoft.Json;

namespace Domain.Generals
{
    public class Company : Entity
    {
        [JsonProperty]
        public string CompanyName { get; protected set; }
        [JsonProperty]
        public string FantasyName { get; protected set; }
        [JsonProperty]
        public string CorporateNumber { get; protected set; }


        public Company()
        { 
        
        }

        public Company(string companyName, string fantasyName, string corporateNumber, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            CorporateNumber = corporateNumber;
        }

        public bool Update(string companyName, string fantasyName, string corporateNumber, string modifiedBy)
        {
            var lUpdated = base.Update(modifiedBy);
            if (lUpdated)
            {
                CompanyName = companyName;
                FantasyName = fantasyName;
                CorporateNumber = corporateNumber;
            }

            return lUpdated;
        }
    }

}
