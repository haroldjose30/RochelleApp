using Domain.Generals;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetStd.Services;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class CompaniesController : BusinessController<Company>
    {
        public CompaniesController(IServiceGeneric<Company> _service) : base(_service)
        {

        }
    }


    public class CustomersController : BusinessController<Customer>
    {
        public CustomersController(IServiceGeneric<Customer> _service) : base(_service)
        {

        }
    }


    public class InvitesController : BusinessController<Invite>
    {
        public InvitesController(IServiceGeneric<Invite> _service) : base(_service)
        {

        }
    }

   
    public class ParamConfigurationsController : BusinessController<ParamConfiguration>
    {
        public ParamConfigurationsController(IServiceGeneric<ParamConfiguration> _service) : base(_service)
        {

        }
    }

    public class PointExtractsController : BusinessController<PointExtract>
    {
        public PointExtractsController(IServiceGeneric<PointExtract> _service) : base(_service)
        {

        }
    }

    public class PointRulesController : BusinessController<PointRule>
    {
        public PointRulesController(IServiceGeneric<PointRule> _service) : base(_service)
        {

        }
    }

    public class ProductsController : BusinessController<Product>
    {
        public ProductsController(IServiceGeneric<Product> _service) : base(_service)
        {

        }
    }


    public class StoreOrdersController : BusinessController<StoreOrder>
    {
        public StoreOrdersController(IServiceGeneric<StoreOrder> _service) : base(_service)
        {

        }
    }


    public class StoreOrderStatusController : BusinessController<StoreOrderStatus>
    {
        public StoreOrderStatusController(IServiceGeneric<StoreOrderStatus> _service) : base(_service)
        {

        }
    }

    public class StoreOrderItemsController : BusinessController<StoreOrderItem>
    {
        public StoreOrderItemsController(IServiceGeneric<StoreOrderItem> _service) : base(_service)
        {

        }
    }

    public class StoreProductsController : BusinessController<StoreProduct>
    {
        public StoreProductsController(IServiceGeneric<StoreProduct> _service) : base(_service)
        {

        }
    }




}
