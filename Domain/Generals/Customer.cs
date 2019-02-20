using System;
using Domain.Base;
using Newtonsoft.Json;

namespace Domain.Generals
{
    public class Customer:EntityWithCompany
    {
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public DateTime BirthDate { get; set; }
        [JsonProperty]
        public string Document { get; set; }
        [JsonProperty]
        public string Email { get; set; }

        public Customer(string name, DateTime birthDate, string document, string email,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            Name = name;
            BirthDate = birthDate;
            Document = document;
            Email = email;
        }
    }
}
