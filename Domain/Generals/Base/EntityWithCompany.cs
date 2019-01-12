using Framework.NetStd.Models;
using Newtonsoft.Json;

namespace Domain.Generals.Base
{
    public class EntityWithCompany:Entity
    {
        [JsonProperty]
        public string CompanyId { get; protected set; }
        [JsonProperty]
        public Company Company { get; protected set; }


        public EntityWithCompany(string companyId, string id, string createdBy) : base(id, createdBy)
        {
            this.CompanyId = companyId;
        }

        protected override string GetNewId()
        {
            return GetDateTimeStr() + this.CompanyId+ this.CreatedBy;
        }

    }





}
