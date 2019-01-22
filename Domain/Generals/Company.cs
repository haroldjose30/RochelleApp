using Framework.NetStd.Models;
using Newtonsoft.Json;

namespace Domain.Generals
{
    public class Company:Entity
    {
        [JsonProperty]
        public string CompanyName { get; private set; }
        [JsonProperty]
        public string FantasyName { get; private set; }
        [JsonProperty]
        public string CorporateNumber { get; private set; }
        [JsonProperty]
        public string StateRegistration { get; private set; }
        [JsonProperty]
        public string Address { get; private set; }
        [JsonProperty]
        public string District { get; private set; }
        [JsonProperty]
        public string Complement { get; private set; }
        [JsonProperty]
        public string State { get; private set; }
        [JsonProperty]
        public string City { get; private set; }
        [JsonProperty]
        public string ZipCode { get; private set; }
        [JsonProperty]
        public string Phone { get; private set; }

        public Company(string id, string createdBy,string companyName, string fantasyName, string corporateNumber, string stateRegistration, string address, string district, string complement, string state, string city, string zipCode, string phone): base(id, createdBy)
        {
            this.CompanyName = companyName;
            this.FantasyName = fantasyName;
            this.CorporateNumber = corporateNumber;
            this.StateRegistration = stateRegistration;
            this.Address = address;
            this.District = district;
            this.Complement = complement;
            this.State = state;
            this.City = city;
            this.ZipCode = zipCode;
            this.Phone = phone;
        }

       

        public static Company CreateNew(string createdBy, string companyName, string fantasyName, string corporateNumber, string stateRegistration, string address, string dristrict, string complement, string state, string city, string zipCode, string phone) 
        {
            var oCompany = new Company(string.Empty, createdBy, companyName, fantasyName, corporateNumber,  stateRegistration, address, dristrict, complement, state, city, zipCode, phone);
            return oCompany;
        }



    }

}
