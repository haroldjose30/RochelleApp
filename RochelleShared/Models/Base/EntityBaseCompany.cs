using System;

namespace RochelleShared.Models
{
    public class EntityBaseCompany:EntityBase
    {
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
