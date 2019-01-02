using System;
using Domain.Models.Base;

namespace Domain.Models
{
    public class Company:Entity
    {
        public string CompanyName { get; set; }

        public string FantasyName { get; set; }

        public string CorporateNumber { get; set; }

        public string StateRegistration { get; set; }

        public string Address { get; set; }

        public string Dristrict { get; set; }

        public string Complement { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; }

    }

}
