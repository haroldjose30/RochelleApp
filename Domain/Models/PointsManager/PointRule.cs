
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



        public PointRule(string name, double pointToGain, RegisterState registerState, PointRuleType pointRuleType,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            Name = name;
            PointToGain = pointToGain;
            RegisterState = registerState;
            PointRuleType = pointRuleType;
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

