using System.Diagnostics;
using Domain.Generals;
using Framework.Core.CommandHandlers;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
{

    public class CreateCompanyCommandHandler : CreateGenericCommandHandler<Company>
    {
        public CreateCompanyCommandHandler(IGenericRepositoryEntity<Company> genericRepositoryEntity, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(genericRepositoryEntity, uow, bus, notifications)
        {
            Debug.WriteLine("RegisterNewCompanyCommandHandler constructor");
        }

    }

}
