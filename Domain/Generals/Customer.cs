using System;
using Domain.Generals.Base;
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

        public Customer(string companyId, string id, string createdBy, string name, DateTime birthDate, string document, string email) : base(companyId, id, createdBy)
        {
            Name = name;
            BirthDate = birthDate;
            Document = document;
            Email = email;
        }

        public static Customer CreateNew(string companyId, string createdBy, string name, DateTime birthDate, string document, string email)
        {
            Customer oCustomer = new Customer(companyId, string.Empty, createdBy, name, birthDate, document, email);
            return oCustomer;
        }
    }
}
