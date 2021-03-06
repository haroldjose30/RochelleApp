﻿using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Framework.Core.Events;
using MediatR;

namespace ApplicationBusiness.Companies.EventHandles
{
    public class CompanyRegisteredEventHandler : INotificationHandler<CreatedGenericEvent<Company>>
    {
        public Task Handle(CreatedGenericEvent<Company> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }
}