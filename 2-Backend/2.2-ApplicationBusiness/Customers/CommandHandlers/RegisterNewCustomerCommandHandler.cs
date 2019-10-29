using System;
using Domain.Generals;
using Framework.Core.CommandHandlers;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace ApplicationBusiness.Customers.CommandHandlers
{
    public class RegisterNewCustomerCommandHandler : RegisterNewGenericCommandHandler<Customer>
    {
       

        public RegisterNewCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_Repository, _uow, _Bus, notifications)
        {
        }
    }
}
