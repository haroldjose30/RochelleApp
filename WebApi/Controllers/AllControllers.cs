using ApplicationBusiness.Services;
using Domain.Models;
using Infra.Data.Repositories;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class CompaniesController : BusinessController<Company>
    {
        public CompaniesController(CompanyService _service) : base(_service)
        {

        }
    }

    /*
    public class CustomersController : BusinessController<Customer>
    {
        public CustomersController(Customerservice _service) : base(_service)
        {

        }
    }


    public class InvitesController : BusinessController<Invite>
    {
        public InvitesController(Inviteservice _service) : base(_service)
        {

        }
    }

   
    public class ParamConfigurationsController : BusinessController<ParamConfiguration>
    {
        public ParamConfigurationsController(ParamConfigurationservice _service) : base(_service)
        {

        }
    }

    public class PointExtractsController : BusinessController<PointExtract>
    {
        public PointExtractsController(PointExtractservice _service) : base(_service)
        {

        }
    }

    public class PointRulesController : BusinessController<PointRule>
    {
        public PointRulesController(PointRuleservice _service) : base(_service)
        {

        }
    }

    public class ProductsController : BusinessController<Product>
    {
        public ProductsController(Productservice _service) : base(_service)
        {

        }
    }


    public class StoreOrdersController : BusinessController<StoreOrder>
    {
        public StoreOrdersController(StoreOrderservice _service) : base(_service)
        {

        }
    }


    public class StoreOrderStatusController : BusinessController<StoreOrderStatus>
    {
        public StoreOrderStatusController(StoreOrderStatusservice _service) : base(_service)
        {

        }
    }

    public class StoreOrderItemsController : BusinessController<StoreOrderItem>
    {
        public StoreOrderItemsController(StoreOrderItemservice _service) : base(_service)
        {

        }
    }

    public class StoreProductsController : BusinessController<StoreProduct>
    {
        public StoreProductsController(StoreProductservice _service) : base(_service)
        {

        }
    }
    */



}
