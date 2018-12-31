using System;
using System.Collections.Generic;
using System.Linq;

namespace RochelleShared.Models
{
    public class StoreOrder:EntityBaseCompany
    {
        public DateTime Date { get; set; }
        public string CustomerFromId { get; set; }
        public Customer CustomerFrom { get; set; }
        public string StoreOrderStatusId { get; set; }
        public StoreOrderStatus StoreOrderStatus { get; set; }
        public IList<StoreOrderItem> Items { get; set; }
    }
}
