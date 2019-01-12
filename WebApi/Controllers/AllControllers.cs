using Domain.Generals;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetStd.Services;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class CompaniesController : GenericController<Company>
    {
        public CompaniesController(IServiceGeneric<Company> _service) : base(_service)
        {

        }
    }


    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IServiceGeneric<Customer> _service) : base(_service)
        {

        }
    }


    public class InvitesController : GenericController<Invite>
    {
        public InvitesController(IServiceGeneric<Invite> _service) : base(_service)
        {

        }
    }

   
    public class ParamConfigurationsController : GenericController<ParamConfiguration>
    {
        public ParamConfigurationsController(IServiceGeneric<ParamConfiguration> _service) : base(_service)
        {

        }
    }

    public class PointAccountController : GenericController<PointAccount>
    {
        public PointAccountController(IServiceGeneric<PointAccount> _service) : base(_service)
        {

        }
    }

    public class PointCustomerController : GenericController<PointCustomer>
    {
        public PointCustomerController(IServiceGeneric<PointCustomer> _service) : base(_service)
        {

        }
    }



    public class PointAccountDetailController : GenericController<PointAccountDetail>
    {
        public PointAccountDetailController(IServiceGeneric<PointAccountDetail> _service) : base(_service)
        {

        }
    }

    public class PointRulesController : GenericController<PointRule>
    {
        public PointRulesController(IServiceGeneric<PointRule> _service) : base(_service)
        {

        }
    }

    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IServiceGeneric<Product> _service) : base(_service)
        {

        }
    }


    public class StoreOrdersController : GenericController<StoreOrder>
    {
        public StoreOrdersController(IServiceGeneric<StoreOrder> _service) : base(_service)
        {

        }
    }


    public class StoreOrderStatusController : GenericController<StoreOrderStatus>
    {
        public StoreOrderStatusController(IServiceGeneric<StoreOrderStatus> _service) : base(_service)
        {

        }
    }

    public class StoreOrderItemsController : GenericController<StoreOrderItem>
    {
        public StoreOrderItemsController(IServiceGeneric<StoreOrderItem> _service) : base(_service)
        {

        }
    }

    public class StoreProductsController : GenericController<StoreProduct>
    {
        public StoreProductsController(IServiceGeneric<StoreProduct> _service) : base(_service)
        {

        }
    }




}
