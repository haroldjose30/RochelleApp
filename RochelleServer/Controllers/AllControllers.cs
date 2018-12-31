using System;
using RochelleServer.Repositories;
using RochelleShared.Models;

namespace RochelleServer.Controllers
{
    /* modelo
   public class Controller : GenericController<>
   {
       public Controller(IRepository _repository) : base(_repository)
       {

       }
   }
   */

    public class CompanyController : GenericController<Company>
    {
        public CompanyController(ICompanyRepository _repository) : base(_repository)
        {

        }
    }

    public class CustomerController : GenericController<Customer>
    {
        public CustomerController(ICustomerRepository _repository) : base(_repository)
        {

        }
    }


    public class InviteController : GenericController<Invite>
    {
        public InviteController(IInviteRepository _repository) : base(_repository)
        {

        }
    }

    public class LoginController : GenericController<Login>
    {
        public LoginController(ILoginRepository _repository) : base(_repository)
        {

        }
    }

    public class ParamConfigurationController : GenericController<ParamConfiguration>
    {
        public ParamConfigurationController(IParamConfigurationRepository _repository) : base(_repository)
        {

        }
    }

    public class PointExtractController : GenericController<PointExtract>
    {
        public PointExtractController(IPointExtractRepository _repository) : base(_repository)
        {

        }
    }

    public class PointRuleController : GenericController<PointRule>
    {
        public PointRuleController(IPointRuleRepository _repository) : base(_repository)
        {

        }
    }

    public class ProductController : GenericController<Product>
    {
        public ProductController(IProductRepository _repository) : base(_repository)
        {

        }
    }


    public class StoreOrderController : GenericController<StoreOrder>
    {
        public StoreOrderController(IStoreOrderRepository _repository) : base(_repository)
        {

        }
    }


    public class StoreOrderStatusController : GenericController<StoreOrderStatus>
    {
        public StoreOrderStatusController(IStoreOrderStatusRepository _repository) : base(_repository)
        {

        }
    }

    public class StoreOrderItemController : GenericController<StoreOrderItem>
    {
        public StoreOrderItemController(IStoreOrderItemRepository _repository) : base(_repository)
        {

        }
    }

    public class StoreProductController : GenericController<StoreProduct>
    {
        public StoreProductController(IStoreProductRepository _repository) : base(_repository)
        {

        }
    }




}
