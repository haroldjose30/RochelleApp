using System;
using Domain.Models.Base;
namespace Domain.Models
{
    public class PointRule:EntityWithCompany
    {
        public string Name { get; set; }
        public double PointToGain { get; set; }
        public RegisterState RegisterState { get; set; }

        public PointRuleType PointRuleType { get; set; }
    }

    public enum PointRuleType
    {
          None,
          ByValue,
          ByInviteSend,
          ByInviteCompleted,
    }
}
