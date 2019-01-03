using Domain.Generals.Base;
namespace Domain.Generals
{
    public class Product:EntityWithCompany
    {
        public string Name { get; set; }
        public RegisterState RegisterState { get; set; }

        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        Product,
        Service
    }
}
