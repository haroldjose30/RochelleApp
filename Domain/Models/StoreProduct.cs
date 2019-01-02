using System;
using Domain.Models.Base;

namespace Domain.Models
{
    public class StoreProduct:EntityWithCompany
    {
        public Product Product { get; set; }
        public double ValuePoint { get; set; }
        public RegisterState RegisterState { get; set; }
    }
}
