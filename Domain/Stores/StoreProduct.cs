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
        public Decimal ValuePoint { get; set; }
        [JsonProperty]
        public Decimal ValueMoney { get; set; }
        [JsonProperty]
        public RegisterState RegisterState { get; set; }

        public StoreProduct(string companyId, string id, string createdBy, Decimal valuePoint, Decimal valueMoney, RegisterState registerState) : base(companyId, id, createdBy)
        {
            //Product = product;
            this.ValuePoint = valuePoint;
            this.RegisterState = registerState;
            this.ValueMoney = valueMoney;
        }

        public static StoreProduct CreateNew(string companyId, string id, string createdBy, Decimal valuePoint, Decimal valueMoney) 
        {
            RegisterState registerState = RegisterState.Enabled;
            StoreProduct oStoreProduct = new StoreProduct( companyId, id,  createdBy,  valuePoint, valueMoney, registerState);
            return oStoreProduct;
        }


    }
}
