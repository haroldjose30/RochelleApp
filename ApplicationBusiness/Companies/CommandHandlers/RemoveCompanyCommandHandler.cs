using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Interfaces;
using Domain.Generals.Companies.Commands;
using Domain.Generals.Companies.Events;
using Domain.Interfaces;
using MediatR;

namespace Domain.Generals.Companies.CommandsHandlers
{
    public class RemoveCompanyCommandHandler: CommandHandler, IRequestHandler<RemoveCompanyCommand>
    {
        ICompanyRepository companyRepository;

        public RemoveCompanyCommandHandler(ICompanyRepository _companyRepository, IUnitOfWork uow, IMediatorHandler Bus) : base(uow, Bus)
        {
            companyRepository = _companyRepository;
        }

        public async Task<Unit> Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("RemoveCompanyCommand");


            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return new Unit();
            }

            companyRepository.Remove(request.Id);

            if (await CommitAsync())
            {
               Bus.RaiseEvent(new CompanyRemovedEvent(request.Id));
            }

            return new Unit();
        }
    }
}
