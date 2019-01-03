using System;
using System.Collections.Generic;
using Domain.Generals.Base;
using Domain.Generals;

namespace Domain.Store
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
