﻿using Domain.Generals;
using Framework.Core.CommandHandlers;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
{
    public class UpdateCompanyCommandHandler : UpdateGenericCommandHandler<Company>
    {


        public UpdateCompanyCommandHandler(IGenericRepositoryEntity<Company> genericRepositoryEntity, IUnitOfWork _uow, IMediatorHandler _Bus, INotificationHandler<DomainNotification> notifications) : base(genericRepositoryEntity, _uow, _Bus, notifications)
        {
        }
    }
}
