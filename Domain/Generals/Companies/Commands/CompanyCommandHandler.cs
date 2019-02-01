using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;
using Domain.Core.Interfaces;
using Domain.Core.Notifications;
using Domain.Generals.Companies.Commands;
using Domain.Generals.Companies.Events;
using MediatR;

namespace Domain.Generals.Companies.CommandHandlers
{
    public class CompanyCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewCompanyCommand>,
        INotificationHandler<UpdateCompanyCommand>,
        INotificationHandler<RemoveCompanyCommand>
    {
        private readonly IRepositoryGeneric<Company> _companyRepository;
        private readonly IMediatorHandler Bus;

        public CompanyCommandHandler(IRepositoryGeneric<Company> companyRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _companyRepository = companyRepository;
            Bus = bus;
        }


        async Task INotificationHandler<RegisterNewCompanyCommand>.Handle(RegisterNewCompanyCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var company = new Company(message.CompanyName,
                                        message.FantasyName,
                                        message.CorporateNumber,
                                        string.Empty,
                                        message.By,
                                        string.Empty,
                                        message.By,
                                        string.Empty,
                                        false);

            //todo: implementar o repositorio especifico para company
            //if (await _companyRepository.GetByCorporateNumber(company.CorporateNumber) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, $"Empresa já cadastrada com o CPF/CNPJ {company.CorporateNumber}"));
                //return;
            }


            await _companyRepository.CreateAsync(company);


            if (Commit())
            {
                Bus.RaiseEvent<Event<Company>,Company>(new CompanyRegisteredEvent(company));
            }

            return;
        }



        public async Task Handle(UpdateCompanyCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }


            var company = new Company(message.CompanyName,
                                        message.FantasyName,
                                        message.CorporateNumber,
                                        message.Id,
                                        string.Empty,
                                        string.Empty,
                                        message.By,
                                        string.Empty,
                                        false);

            //todo: verifica se CorporateNumber ja esta cadastrado, pois este deve ser unico no sistema
            //nao permitindo que 2 empresas sejam cadastrada com o mesmo CPF ou CNPJ
            var existingCompany = company; //_companyRepository.GetByEmail(company.Email);

            if (existingCompany != null && existingCompany.Id != company.Id)
            {
                if (!existingCompany.Equals(company))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The company e-mail has already been taken."));
                    return;
                }
            }

            _companyRepository.UpdateAsync(company);

            if (Commit())
            {
                Bus.RaiseEvent<Event<Company>, Company>(new CompanyUpdatedEvent(company));
            }

            return;
        }

        public Task Handle(RemoveCompanyCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var company = new Company(message.CompanyName,
                                       message.FantasyName,
                                       message.CorporateNumber,
                                       message.Id,
                                       string.Empty,
                                       string.Empty,
                                       message.By,
                                       string.Empty,
                                       false);


            _companyRepository.DeleteAsync(company);

            if (Commit())
            {
                Bus.RaiseEvent<Event<Company>, Company>(new CompanyRemovedEvent(company));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _companyRepository.Dispose();
        }

       
    }
}
