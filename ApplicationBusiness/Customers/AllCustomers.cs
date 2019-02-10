using Domain.Core.CommandHandlers;
using Domain.Core.Interfaces;
using Domain.Generals;

namespace ApplicationBusiness.Services
{
    /*
    public class CustomerService : GenericService<Customer>
    {
        public CustomerService(IRepository<Customer> repository, IMediatorHandler bus) : base(repository, bus)
        {
        }
    }
    */


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

}
