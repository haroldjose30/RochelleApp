using System;
using Domain.Generals;
using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.Store
{
    public class StoreProduct:EntityWithCompany
    {

        [JsonProperty]
        public Product Product { get; set; }
        [JsonProperty]
        public double ValuePoint { get; set; }
        [JsonProperty]
        public RegisterState RegisterState { get; set; }

        public StoreProduct(string companyId, string id, string createdBy, double valuePoint, RegisterState registerState) : base(companyId, id, createdBy)
        {
            //Product = product;
            ValuePoint = valuePoint;
            RegisterState = registerState;
        }

        public static StoreProduct CreateNew(string companyId, string id, string createdBy, double valuePoint) 
        {
            RegisterState registerState = RegisterState.Enabled;
            StoreProduct oStoreProduct = new StoreProduct( companyId, id,  createdBy,  valuePoint, registerState);
            return oStoreProduct;
        }


    }
}
