using System;
namespace RochelleShared.Models
{
    public class StoreProduct:EntityBase
    {
        public Product Product { get; set; }
        public double ValuePoint { get; set; }
        public RegisterState State { get; set; }

    }
}
