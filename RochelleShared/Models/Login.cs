using System;
namespace RochelleShared.Models
{
    public class Login:EntityBaseCompany
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public RegisterState State { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }


}
