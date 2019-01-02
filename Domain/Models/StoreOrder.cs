using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models.Base;

namespace Domain.Models
{
    public class StoreOrder:EntityWithCompany
    {
        public DateTime Date { get; set; }
        public string CustomerFromId { get; set; }
        public Customer CustomerFrom { get; set; }
        public string StoreOrderStatusId { get; set; }
        public StoreOrderStatus StoreOrderStatus { get; set; }
        public IList<StoreOrderItem> Items { get; set; }
    }
}
