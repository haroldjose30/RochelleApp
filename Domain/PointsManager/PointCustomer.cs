using System;
using Domain.Generals;
using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.PointsManager
{
    public class PointCustomer: EntityWithCompany
    {
        [JsonProperty]
        public string CustomerId { get; set; }
        [JsonProperty]
        public Customer Customer { get; set; }
        [JsonProperty]
        public int InvitesQuantity { get; private set; }

        public PointCustomer(string companyId, string id, string createdBy, string customerId) : base(companyId, id, createdBy)
        {
            this.CustomerId = customerId;
        }


    }
}
