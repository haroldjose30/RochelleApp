using System;
using Domain.Models.Base;
namespace Domain.Models
{
    public class Customer:EntityWithCompany
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
