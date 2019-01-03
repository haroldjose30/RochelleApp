using System;
using Domain.Generals;
using Domain.Generals.Base;

namespace Domain.PointsManager
{
    public class Invite:EntityWithCompany
    {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string CustomerFromId { get; set; }
        public Customer CustomerFrom { get; set; }

        public String CustomerToId { get; set; }
        public Customer CustomerTo { get; set; }

        public InviteStatus InviteStatus { get; set; }
    }

    public enum InviteStatus
    {
        Created,
        Used,
        Expired,
        Canceled
    }
}
