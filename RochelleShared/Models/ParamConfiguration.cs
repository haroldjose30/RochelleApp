using System;
namespace RochelleShared.Models
{
    public class ParamConfiguration:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public ParamConfigurationType Type { get; set; }
    }

    public enum ParamConfigurationType
    {
        character,
        number,
    }
}
