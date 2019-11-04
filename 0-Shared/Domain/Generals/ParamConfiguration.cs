using Domain.Base;
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

        //public ParamConfiguration(string name, string description, string value, ParamConfigurationType type,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        //{
        //    Name = name;
        //    Description = description;
        //    Value = value;
        //    Type = type;
        //}

       
    }

    public enum ParamConfigurationType
    {
        character = 0,
        number = 1,
    }
}
