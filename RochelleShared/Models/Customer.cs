using System;
namespace RochelleShared.Models
{
    public class Customer:EntityBaseCompany
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
