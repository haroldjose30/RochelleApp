using Domain.Core.Events;
using Domain.Generals;

namespace ApplicationBusiness.Companies.Events
{
    public class CompanyRegisteredEvent : EventNotification
    {
        public CompanyRegisteredEvent(Company _entity)
        {

        }
    }


}
