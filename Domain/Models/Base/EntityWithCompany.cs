using System;

namespace Domain.Models.Base
{
    public class EntityWithCompany:Entity
    {
        public string CompanyId { get; set; } 
        public Company Company { get; set; }
    }
}
