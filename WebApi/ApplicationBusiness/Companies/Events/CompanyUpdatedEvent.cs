using Domain.Core.Events;
using Domain.Generals;

namespace ApplicationBusiness.Companies.Events
{
    public class CompanyUpdatedEvent : EventNotification
    {
        public CompanyUpdatedEvent(Company _entity)
        {

        }
    }
}
