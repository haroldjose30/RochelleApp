using System;
using Domain.Models.Base;
namespace Domain.Models
{
    public class User:EntityWithCompany
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RegisterState State { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }


}
