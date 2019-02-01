using System;
using Domain.Core.Events;

namespace Domain.Generals.Companies.Events
{
    public class CompanyRemovedEvent : Event<Company>
    {
        public CompanyRemovedEvent(Company _entity) : base(_entity)
        {

        }
    }
}
