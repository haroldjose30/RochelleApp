using System;
namespace RochelleShared.Models
{
    public class Invite:EntityBase
    {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }

       
        public Customer CustomerFrom { get; set; }

        public Customer CustomerTo { get; set; }

        public InviteStatus InviteStatus
        {
            get => default(InviteStatus);
            set
            {
            }
        }
    }

    public enum InviteStatus
    {
        Created,
        Used,
        Expired,
        Canceled
    }
}
