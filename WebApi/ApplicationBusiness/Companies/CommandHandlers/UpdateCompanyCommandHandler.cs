using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ApplicationBusiness.Companies.Commands;
using ApplicationBusiness.Companies.Events;
using Domain.Core.Commands;
using Domain.Core.Interfaces;
using Domain.Generals;
using Domain.Interfaces;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
{
    public class UpdateCompanyCommandHandler : CommandHandler, IRequestHandler<UpdateCompanyCommand>
    {
        ICompanyRepository companyRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository _companyRepository, IUnitOfWork uow, IMediatorHandler Bus) : base(uow, Bus)
        {
            companyRepository = _companyRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("UpdateCompanyCommand");



            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }


            var company = new Company(
                                        request.CompanyName,
                                        request.FantasyName,
                                        request.CorporateNumber,
                                        request.Id,
                                        request.By,
                                        "",
                                        request.By,
                                        "",
                                        false);
            /*
            //todo: verifica se CorporateNumber ja esta cadastrado, pois este deve ser unico no sistema
            //nao permitindo que 2 empresas sejam cadastrada com o mesmo CPF ou CNPJ
            var existingCompany = company; //_companyRepository.GetByEmail(company.Email);

            if (existingCompany != null && existingCompany.Id != company.Id)
            {
                if (!existingCompany.Equals(company))
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "The company e-mail has already been taken."));
                    return new Unit();
                }
            }
            */

            companyRepository.Update(company);

            if (await CommitAsync())
            {
                Bus.PublishEvent(new CompanyUpdatedEvent(company));
            }

            return new Unit();
        }
    }
}
