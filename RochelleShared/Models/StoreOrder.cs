using System;
using System.Collections.Generic;

namespace RochelleShared.Models
{
    public class StoreOrder:EntityBaseCompany
    {
        public DateTime Date { get; set; }
        public Customer CustomerFrom { get; set; }
        public StoreOrderStatus StoreOrderStatus { get; set; }
        public IList<StoreOrderItem> Items { get; set; }
    }
}
