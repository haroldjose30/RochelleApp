using System;
using Domain.Generals;
using Domain.Generals.Base;

namespace Domain.Store
{
    public class StoreProduct:EntityWithCompany
    {
        public Product Product { get; set; }
        public double ValuePoint { get; set; }
        public RegisterState RegisterState { get; set; }
    }
}
