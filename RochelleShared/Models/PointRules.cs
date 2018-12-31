using System;
namespace RochelleShared.Models
{
    public class PointRules:EntityBase
    {
        public string Name { get; set; }
        public double PointToGain { get; set; }
        public RegisterState State { get; set; }

        public PointRulesType PointRulesType { get; set; }
    }

    public enum PointRulesType
    {
          None,
          ByValue,
          ByInviteSend,
          ByInviteCompleted,
    }
}
