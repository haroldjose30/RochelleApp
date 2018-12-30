using System;
namespace RochelleShared.Models
{
    public class PointRules:EntityBase
    {
        public string Name { get; set; }
        public PointType Type { get; set; }
        public double PointToGain { get; set; }
        public RegisterState State { get; set; }
    }

    public enum PointType
    {
          None,
          ByValue,
          ByInviteSend,
          ByInviteCompleted,
    }
}
