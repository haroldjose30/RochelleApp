
using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.Generals
{
    public class Product:EntityWithCompany
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public RegisterState RegisterState { get; set; }
        [JsonProperty]
        public ProductType ProductType { get; set; }



        public Product(string name, RegisterState registerState, ProductType productType,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            Name = name;
            RegisterState = registerState;
            ProductType = productType;
        }
       
    }

    public enum ProductType
    {
        Product,
        Service
    }
}
