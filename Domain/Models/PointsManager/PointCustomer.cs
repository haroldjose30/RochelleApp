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

        public PointCustomer(string customerId, int invitesQuantity,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            this.CustomerId = customerId;
            this.InvitesQuantity = invitesQuantity;
        }
    }
}
