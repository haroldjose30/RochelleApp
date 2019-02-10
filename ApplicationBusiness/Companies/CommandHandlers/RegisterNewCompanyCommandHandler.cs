using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Interfaces;
using Domain.Generals.Companies.Commands;
using Domain.Generals.Companies.Events;
using Domain.Interfaces;
using MediatR;

namespace Domain.Generals.Companies.CommandHandlers
{
    public class RegisterNewCompanyCommandHandler: CommandHandler , IRequestHandler<RegisterNewCompanyCommand>
    {
        ICompanyRepository companyRepository;

        public RegisterNewCompanyCommandHandler(ICompanyRepository _companyRepository,IUnitOfWork uow, IMediatorHandler _Bus) : base(uow, _Bus)
        {
            companyRepository = _companyRepository;
        }

        public async Task<Unit> Handle(RegisterNewCompanyCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("RegisterNewCompanyCommand");

            if (!request.IsValid())
            {
                //NotifyValidationErrors(request);
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

            //todo: implementar o repositorio especifico para company
            //if (await _companyRepository.GetByCorporateNumber(company.CorporateNumber) != null)
            {
                //Bus.RaiseEvent(new DomainNotification(request.MessageType, $"Empresa já cadastrada com o CPF/CNPJ {company.CorporateNumber}"));
                //return;
            }


            var companAdded = companyRepository.Add(company);


            if (await CommitAsync())
            {
                Bus.RaiseEvent(new CompanyRegisteredEvent(companAdded));
            }



            return new Unit();
        }
    }
}
