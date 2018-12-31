using System;
namespace RochelleShared.Models
{
    public class Product:EntityBaseCompany
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
