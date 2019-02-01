using System;
using Domain.Core.Events;

namespace Domain.Generals.Companies.Events
{
    public class CompanyRegisteredEvent : Event<Company>
    {
        public CompanyRegisteredEvent(Company _entity) : base(_entity)
        {

        }
    }
}
