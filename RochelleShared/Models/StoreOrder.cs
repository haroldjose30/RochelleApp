using System;
using System.Collections.Generic;

namespace RochelleShared.Models
{
    public class StoreOrder:EntityBase
    {
        public DateTime Date { get; set; }
        public Customer CustomerFrom { get; set; }
        public StoreOrderStatus Status { get; set; }
        public IList<StoreOrderItem> Items { get; set; }
    }
}
