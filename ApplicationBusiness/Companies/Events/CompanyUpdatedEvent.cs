using System;
using Domain.Core.Events;

namespace Domain.Generals.Companies.Events
{
    public class CompanyUpdatedEvent : EventNotification
    {
        public CompanyUpdatedEvent(Company _entity)
        {

        }
    }
}
