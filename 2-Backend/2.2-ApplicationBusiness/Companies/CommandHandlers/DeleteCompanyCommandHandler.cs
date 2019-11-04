using Domain.Generals;
using Framework.Core.CommandHandlers;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
{
    public class DeleteCompanyCommandHandler: DeleteGenericCommandHandler<Company>
    {
       

        public DeleteCompanyCommandHandler(IGenericRepository<Company> genericRepository, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(genericRepository, _uow, _Bus, notifications)
        {
        }
    }
}
