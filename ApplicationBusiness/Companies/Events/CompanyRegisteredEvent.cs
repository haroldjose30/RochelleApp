using Domain.Core.Events;

namespace Domain.Generals.Companies.Events
{
    public class CompanyRegisteredEvent : EventNotification
    {
        public CompanyRegisteredEvent(Company _entity)
        {

        }
    }
}
