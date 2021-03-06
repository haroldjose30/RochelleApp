﻿using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Framework.Core.Events;
using MediatR;

namespace ApplicationBusiness.Companies.EventHandles
{

    public class CompanyUpdatedEventHandler : INotificationHandler<UpdatedGenericEvent<Company>>
    {
        public Task Handle(UpdatedGenericEvent<Company> notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            Debug.WriteLine("GenericRegisteredEventHandler");

            return Task.CompletedTask;
        }
    }

}
