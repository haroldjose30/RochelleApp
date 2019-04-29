
using System;
using Domain.Base;
using Domain.Generals;

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

        //public StoreProduct(Decimal valuePoint, Decimal valueMoney, RegisterState registerState,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        //{
        //    //Product = product;
        //    this.ValuePoint = valuePoint;
        //    this.RegisterState = registerState;
        //    this.ValueMoney = valueMoney;
        //}

    }
}
