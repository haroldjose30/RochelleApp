using System;
using System.Diagnostics;
using Domain.Core.Events;

namespace ApplicationBusiness.Companies.Events
{
    public class CompanyRemovedEvent : EventNotification
    {
        public CompanyRemovedEvent(string id) 
        {
            Debug.WriteLine("CompanyRemovedEvent");
        }
    }
}
