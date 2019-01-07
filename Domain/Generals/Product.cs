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


        public Product(string companyId, string id, string createdBy,string name, RegisterState registerState, ProductType productType) : base(companyId, id, createdBy)
        {
            Name = name;
            RegisterState = registerState;
            ProductType = productType;
        }

        public static Product CreateNew(string companyId, string id, string createdBy, string name, ProductType productType) 
        {
            RegisterState registerState = RegisterState.Enabled;
            Product oProduct = new Product(companyId, string.Empty, createdBy, name, registerState, productType);
            return oProduct;
        }

    }

    public enum ProductType
    {
        Product,
        Service
    }
}
