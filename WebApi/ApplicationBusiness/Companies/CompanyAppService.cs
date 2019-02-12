using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationBusiness.Companies.CommandHandlers;
using ApplicationBusiness.Companies.Commands;
using Domain.Core.Interfaces;
using Domain.Generals;
using Domain.Interfaces;
using MediatR;

namespace ApplicationBusiness.Companies.Services
{

    public delegate object ServiceFactory(Type serviceType);

    public class CompanyAppService : ICompanyAppService
    {
       //private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;
        IMediator _mediator;

        public CompanyAppService(//IMapper mapper,
                                  ICompanyRepository companyRepository,
                                  IMediatorHandler bus,
                                  IMediator mediator
                                  //IEventStoreRepository eventStoreRepository
                                  )
        {
           //_mapper = mapper;
           _companyRepository = companyRepository;
            Bus = bus;
            _mediator = mediator;
            //_eventStoreRepository = eventStoreRepository;
        }

       
        public async Task<IEnumerable<Company>> GetAllAsync()
        {

            await _mediator.Publish(new PingNotification());
            await _mediator.Publish<PingNotification>(new PingNotification());


            return null;
            //return _companyRepository.GetAll();//.ProjectTo<CompanyViewModel>();
        }

        public Company GetById(string id)
        {
            //return _mapper.Map<CompanyViewModel>(_companyRepository.GetById(id));
            return _companyRepository.GetById(id);
        }

        public Company Register(Company company)
        {
            //var registerCommand = _mapper.Map<RegisterNewCompanyCommand>(companyViewModel);
            //Bus.SendCommand(registerCommand);

            var oRegisterNewCompanyCommand = new RegisterNewCompanyCommand(company);
            Bus.SendCommand(oRegisterNewCompanyCommand);
            //this.Mediator.Send(oRegisterNewCompanyCommand);
            return null;

        }

        public Company Update(Company company)
        {
            //var updateCommand = _mapper.Map<UpdateCompanyCommand>(companyViewModel);
            //Bus.SendCommand(updateCommand);

            var oUpdateCompanyCommand = new UpdateCompanyCommand(company);
            Bus.SendCommand(oUpdateCompanyCommand);


            return null;
        }

        public bool Remove(string id, string removedBy)
        {
            var removeCommand = new RemoveCompanyCommand(id, removedBy);
            Bus.SendCommand(removeCommand);
            return false;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

       
    }
}
