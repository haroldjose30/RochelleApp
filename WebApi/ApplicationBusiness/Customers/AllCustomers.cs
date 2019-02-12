using Domain.Core.CommandHandlers;
using Domain.Core.EventHandlers;
using Domain.Core.Interfaces;
using Domain.Generals;

namespace ApplicationBusiness.Companies.Services
{
    public class RegisterNewCustomerCommandHandler : RegisterNewGenericCommandHandler<Customer>
   {
       public RegisterNewCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork uow, IMediatorHandler _Bus) : base(_Repository, uow, _Bus)
       {
       }
   }

    public class UpdateCustomerCommandHandler : UpdateGenericCommandHandler<Customer>
    {
        public UpdateCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork uow, IMediatorHandler _Bus) : base(_Repository, uow, _Bus)
        {
        }
    }

    public class RemoveCustomerCommandHandler : RemoveGenericCommandHandler<Customer>
    {
        public RemoveCustomerCommandHandler(IRepository<Customer> _Repository, IUnitOfWork uow, IMediatorHandler _Bus) : base(_Repository, uow, _Bus)
        {
        }
    }

    public class CustomerRegisteredEventHandler : GenericRegisteredEventHandler<Customer>
    {
       
    }

    public class CustomerUpdatedEventHandler : GenericUpdatedEventHandler<Customer>
    {
       
    }


    public class CustomerRemovedEventHandler : GenericRemovedEventHandler<Customer>
    {

    }

}
