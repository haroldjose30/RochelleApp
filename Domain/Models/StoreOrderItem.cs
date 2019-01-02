﻿using Domain.Models.Base;
namespace Domain.Models
{
    public class StoreOrderItem:EntityWithCompany
    {
        public string ProductId { get; set; }
        public StoreProduct Product { get; set; }
        public double Quantity { get; set; }
        public double ValuePoint { get; set; }
    }
}