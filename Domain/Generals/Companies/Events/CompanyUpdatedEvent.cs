using System;
using Domain.Core.Events;

namespace Domain.Generals.Companies.Events
{
    public class CompanyUpdatedEvent : Event<Company>
    {
        public CompanyUpdatedEvent(Company _entity) : base(_entity)
        {

        }
    }
}
