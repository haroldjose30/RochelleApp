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

        public bool Create(string companyName, string fantasyName, string corporateNumber,string by, string id = null)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            CorporateNumber = corporateNumber;
            return base.Create(by, id);
        }

        public bool Update(string companyName, string fantasyName, string corporateNumber, string by)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            CorporateNumber = corporateNumber;
            return base.Update(by);
        }
        
    }

}
