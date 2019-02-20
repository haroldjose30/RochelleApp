using Domain.Generals;
using Framework.Core.CommandHandlers;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
{
    public class UpdateCompanyCommandHandler : UpdateGenericCommandHandler<Company>
    {


        public UpdateCompanyCommandHandler(IRepository<Company> _Repository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(_Repository, _uow, _Bus, notifications)
        {
        }
    }
}
