using Framework.NetStd.Models;

namespace Domain.Generals.Base
{
    public class EntityWithCompany:Entity
    {
        public string CompanyId { get; private set; }
        public Company Company { get; private set; }


        public EntityWithCompany(string companyId, string id, string createdBy) : base(id, createdBy)
        {
            this.CompanyId = companyId;
        }

        protected override string GetNewId()
        {
            return GetDateTimeStr() + this.CompanyId+ this.CreatedBy;
        }

    }





}
