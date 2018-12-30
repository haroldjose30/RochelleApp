using System;
namespace RochelleShared.Models
{
    public class Invite:EntityBase
    {
        public string Code { get; set; }
        public InviteState State { get; set; }
        public string LoginIdFrom { get; set; }
        public string LoginIdTo { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public enum InviteState
    {
        Created,
        Used,
        Expired,
        Canceled
    }
}
