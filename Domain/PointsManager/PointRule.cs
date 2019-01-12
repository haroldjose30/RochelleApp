using System;
using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.PointsManager
{
    public class PointRule:EntityWithCompany
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public double PointToGain { get; set; }
        [JsonProperty]
        public RegisterState RegisterState { get; set; }
        [JsonProperty]
        public PointRuleType PointRuleType { get; set; }

        public PointRule(string companyId, string id, string createdBy,string name, double pointToGain, RegisterState registerState, PointRuleType pointRuleType) : base(companyId, id, createdBy)
        {
            Name = name;
            PointToGain = pointToGain;
            RegisterState = registerState;
            PointRuleType = pointRuleType;
        }

        public static PointRule CreateNew(string companyId, string createdBy, string name, double pointToGain,  PointRuleType pointRuleType)
        {
            RegisterState registerState = RegisterState.Enabled;
            PointRule oPointRule = new PointRule(companyId, string.Empty, createdBy, name, pointToGain, registerState, pointRuleType);
            return oPointRule;
        }



    }

    public enum PointRuleType
    {
          None,
          ByValue,
          ByInviteSend,
          ByInviteCompleted,
    }
}
