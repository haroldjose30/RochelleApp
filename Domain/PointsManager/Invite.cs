using System;
using Domain.Generals;
using Domain.Generals.Base;
using shortid;

namespace Domain.PointsManager
{
    public class Invite : EntityWithCompany
    {


        public string Code { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public string CustomerFromId { get; set; }
        public Customer CustomerFrom { get; set; }

        public String CustomerToId { get; set; }
        public Customer CustomerTo { get; set; }

        public InviteStatus InviteStatus { get; set; }

        public Invite(string companyId, string id, string createdBy, string code, DateTime? expirationDate, string customerFromId, string customerToId, InviteStatus inviteStatus) : base(companyId, id, createdBy)
        {
            Code = code;
            ExpirationDate = expirationDate;
            CustomerFromId = customerFromId;
            //CustomerFrom = customerFrom;
            CustomerToId = customerToId;
            //CustomerTo = customerTo;
            InviteStatus = inviteStatus;
        }



        public Invite CreateNew(string companyId, string createdBy, string customerFromId, string customerToId)
        {
            string code = GenerateNewInviteCode();
            DateTime? expirationDate = CalcExpirationDate();
            InviteStatus inviteStatus = InviteStatus.Created;
            Invite oInvite = new Invite(companyId, string.Empty, createdBy, code, expirationDate, customerFromId, customerToId, inviteStatus);
            return oInvite;
        }

        private DateTime? CalcExpirationDate()
        {
            return null;
        }

        private string GenerateNewInviteCode()
        {
            string code = ShortId.Generate(true, false,5);
            return code;
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
