using System;
using Domain.Generals;
using Framework.Core.Models;
using Newtonsoft.Json;

namespace Domain.Base
{
    public class EntityWithCompany:Entity
    {
       

        [JsonProperty]
        public Guid CompanyId { get; protected set; }
        [JsonProperty]
        public Company Company { get; protected set; }
        
        protected bool Create(Guid companyId,string by,Guid id = default)
        {
            CompanyId = companyId;
            return base.Create(by, id);
        }
        
    }





}

