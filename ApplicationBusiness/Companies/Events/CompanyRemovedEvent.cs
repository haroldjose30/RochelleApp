using System;
using System.Diagnostics;
using Domain.Core.Events;

namespace Domain.Generals.Companies.Events
{
    public class CompanyRemovedEvent : EventNotification
    {
        public CompanyRemovedEvent(string id) 
        {
            Debug.WriteLine("CompanyRemovedEvent");
        }
    }
}
