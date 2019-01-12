using System;
using Domain.Generals.Base;
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

        public StoreOrderItem(string companyId, string id, string createdBy, string productId, Decimal quantity, Decimal valuePoint) : base(companyId, id, createdBy)
        {
            ProductId = productId;
            //Product = product;
            Quantity = quantity;
            ValuePoint = valuePoint;
        }

        public static StoreOrderItem CreateNew(string companyId, string createdBy, string productId, Decimal quantity, Decimal valuePoint) 
        {
            StoreOrderItem oStoreOrderItem = new StoreOrderItem(companyId, string.Empty, createdBy, productId, quantity, valuePoint);
            return oStoreOrderItem;
        }


    }
}