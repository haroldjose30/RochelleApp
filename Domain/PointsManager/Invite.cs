using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Domain.Generals;
using Domain.Generals.Base;

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



        public static Invite CreateNew(string companyId, string createdBy, string customerFromId, string customerToId)
        {

            string code = Invite.GenerateNewInviteCode();
            DateTime? expirationDate = Invite.CalcExpirationDate();
            InviteStatus inviteStatus = InviteStatus.Created;
            Invite oInvite = new Invite(companyId, string.Empty, createdBy, code, expirationDate, customerFromId, customerToId, inviteStatus);
            return oInvite;
        }

        private static DateTime? CalcExpirationDate()
        {
            return null;
        }

        private static string GenerateNewInviteCode()
        {
            string code = DateTime.Now.ToUniversalTime().ToString("yyMMddHHmmssfff");//Some input text that includes the datetime the hash was created;

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(code));

                //make sure the hash is only alpha numeric to prevent charecters that may break the url
                var codeList = Convert.ToBase64String(hash).ToUpper().ToCharArray().Where(x => char.IsLetterOrDigit(x)).Take(10);

                code = "";
                foreach (var item in codeList)
                {
                    code += item.ToString();
                }

                return code;

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
