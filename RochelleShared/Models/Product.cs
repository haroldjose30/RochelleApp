using System;
namespace RochelleShared.Models
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public RegisterState State { get; set; }
    }

    public enum ProductType
    {
        Product,
        Service
    }
}
