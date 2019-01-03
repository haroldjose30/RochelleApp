using Framework.NetStd.Models;

namespace Domain.Generals.Base
{
    public class EntityWithCompany:Entity
    {
        public string CompanyId { get; set; } 
        public Company Company { get; set; }
    }
}
