using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ApplicationBusiness.Companies.Commands;
using ApplicationBusiness.Companies.Events;
using Domain.Core.Commands;
using Domain.Core.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace ApplicationBusiness.Companies.CommandHandlers
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
               Bus.PublishEvent(new CompanyRemovedEvent(request.Id));
            }

            return new Unit();
        }
    }
}
