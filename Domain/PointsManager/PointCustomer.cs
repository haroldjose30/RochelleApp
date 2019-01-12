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

        public PointCustomer(string companyId, string id, string createdBy, string customerId, int invitesQuantity) : base(companyId, id, createdBy)
        {
            this.CustomerId = customerId;
            this.InvitesQuantity = invitesQuantity;
        }

        public static PointCustomer CreateNew(string companyId, string createdBy, string customerId, int invitesQuantity)
        {
            PointCustomer oPointCustomer = new PointCustomer(companyId, string.Empty, createdBy, customerId, invitesQuantity);
            return oPointCustomer;
        }


    }
}
