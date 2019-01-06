using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.Generals
{
    public class ParamConfiguration:EntityWithCompany
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string Value { get; set; }
        [JsonProperty]
        public ParamConfigurationType Type { get; set; }

        public ParamConfiguration(string companyId, string id, string createdBy, string name, string description, string value, ParamConfigurationType type) : base(companyId, id, createdBy)
        {
            Name = name;
            Description = description;
            Value = value;
            Type = type;
        }

        public static ParamConfiguration CreateNew(string companyId, string createdBy, string name, string description, string value, ParamConfigurationType type)
        {
            ParamConfiguration oParamConfiguration = new ParamConfiguration( companyId, string.Empty,  createdBy,  name,  description,  value, type);
            return oParamConfiguration;
        }
    }

    public enum ParamConfigurationType
    {
        character,
        number,
    }
}
