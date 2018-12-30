using System;
namespace RochelleShared.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string InsertedDate { get; set; }
        public string InsertedUser { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public string DeletedDate { get; set; }
        public string DeletedUser { get; set; }

        public string Name { get; set; }        
    }
}
