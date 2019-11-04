using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Framework.Core.CommandHandlers;
using Framework.Core.Commands;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
{

    public class CreateCompanyCommandHandler : CreateGenericCommandHandler<Company>
    {
        public CreateCompanyCommandHandler(IGenericRepository<Company> genericRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(genericRepository, uow, bus, notifications)
        {
            Debug.WriteLine("RegisterNewCompanyCommandHandler constructor");
        }

    }

}
