using Domain.Generals;
using Framework.Core.Models;
using Newtonsoft.Json;

namespace Domain.Base
{
    public class EntityWithCompany:Entity
    {
       

        [JsonProperty]
        public string CompanyId { get; protected set; }
        [JsonProperty]
        public Company Company { get; protected set; }
        
        protected bool Create(string companyId,string by,string id = null)
        {
            CompanyId = companyId;
            return base.Create(by, id);
        }
        protected override string GetNewId()
        {
            return GetDateTimeStr() + this.CompanyId+ this.CreatedBy;
        }

    }





}

