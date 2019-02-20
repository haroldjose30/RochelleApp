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

        public EntityWithCompany(string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            this.CompanyId = companyId;
            //if id is empyty, get new id automaticaly
            if (string.IsNullOrWhiteSpace(id))
                id = this.GetNewId();

        }

        protected override string GetNewId()
        {
            return GetDateTimeStr() + this.CompanyId+ this.CreatedBy;
        }

    }





}

