
using System;
using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Store
{
    public class StoreOrderItem:EntityWithCompany
    {
        [JsonProperty]
        public string StoreOrderId { get; private set; }
        [JsonProperty]
        public StoreOrder StoreOrder { get; private set; }
        [JsonProperty]
        public string ProductId { get; private set; }
        [JsonProperty]
        public StoreProduct Product { get; private set; }
        [JsonProperty]
        public Decimal Quantity { get; private set; }
        [JsonProperty]
        public Decimal ValuePoint { get; private set; }

        //public StoreOrderItem(string productId, Decimal quantity, Decimal valuePoint,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        //{
        //    ProductId = productId;
        //    //Product = product;
        //    Quantity = quantity;
        //    ValuePoint = valuePoint;
        //}


    }
}
