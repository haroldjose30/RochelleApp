using System;
namespace RochelleShared.Models
{
    public class StoreProduct:EntityBaseCompany
    {
        public Product Product { get; set; }
        public double ValuePoint { get; set; }
        public RegisterState RegisterState { get; set; }
    }
}
