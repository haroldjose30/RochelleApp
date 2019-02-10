
using System;
using System.Collections.Generic;
using Domain.Generals.Base;
using Domain.Generals;
using Newtonsoft.Json;


namespace Domain.Store
{
    public class StoreOrder:EntityWithCompany
    {

        [JsonProperty]
        public DateTime Date { get; set; }
        [JsonProperty]
        public string CustomerFromId { get; set; }
        [JsonProperty]
        public Customer CustomerFrom { get; set; }
        [JsonProperty]
        public string StoreOrderStatusId { get; set; }
        [JsonProperty]
        public StoreOrderStatus StoreOrderStatus { get; set; }
        [JsonProperty]
        public List<StoreOrderItem> Items { get; set; }

        public StoreOrder(DateTime date, string customerFromId, string storeOrderStatusId,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            this.Date = date;
            this.CustomerFromId = customerFromId;
            //CustomerFrom = customerFrom;
            this.StoreOrderStatusId = storeOrderStatusId;
            //StoreOrderStatus = storeOrderStatus;
            this.Items = new List<StoreOrderItem>();
        }

       

        public void AddItem(StoreOrderItem storeOrderItem )
        {
            this.Items.Add(storeOrderItem);
        }


    }
}
