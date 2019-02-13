using System.Diagnostics;
using Domain.Core.Services;
using Domain.Generals;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{

    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IGenericService<Customer> _service) : base(_service)
        {
            Debug.WriteLine("CustomersController");
        }
    }



    /*
     
    public class CompaniesController : GenericController<Company>
    {
        public CompaniesController( IMediator _mediator, 
                                    IGenericService<Company> _service) : base(_mediator,_service)
        {
            Debug.WriteLine(_mediator);
        }
    }
    
   
    public class InvitesController : GenericController<Invite>
    {
        public InvitesController(IMediator _mediator, IServiceGeneric<Invite> _service) : base(_mediator, _service)
        {

        }
    }

   
    public class ParamConfigurationsController : GenericController<ParamConfiguration>
    {
        public ParamConfigurationsController(IMediator _mediator, IServiceGeneric<ParamConfiguration> _service) : base(_mediator, _service)
        {

        }
    }

    public class PointAccountController : GenericController<PointAccount>
    {
        public PointAccountController(IMediator _mediator, IServiceGeneric<PointAccount> _service) : base(_mediator, _service)
        {

        }
    }

    public class PointCustomerController : GenericController<PointCustomer>
    {
        public PointCustomerController(IMediator _mediator, IServiceGeneric<PointCustomer> _service) : base(_mediator, _service)
        {

        }
    }



    public class PointAccountDetailController : GenericController<PointAccountDetail>
    {
        public PointAccountDetailController(IMediator _mediator, IServiceGeneric<PointAccountDetail> _service) : base(_mediator, _service)
        {

        }
    }

    public class PointRulesController : GenericController<PointRule>
    {
        public PointRulesController(IMediator _mediator, IServiceGeneric<PointRule> _service) : base(_mediator, _service)
        {

        }
    }

    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IMediator _mediator, IServiceGeneric<Product> _service) : base(_mediator, _service)
        {

        }
    }


    public class StoreOrdersController : GenericController<StoreOrder>
    {
        public StoreOrdersController(IMediator _mediator, IServiceGeneric<StoreOrder> _service) : base(_mediator, _service)
        {

        }
    }


    public class StoreOrderStatusController : GenericController<StoreOrderStatus>
    {
        public StoreOrderStatusController(IMediator _mediator, IServiceGeneric<StoreOrderStatus> _service) : base(_mediator, _service)
        {

        }
    }

    public class StoreOrderItemsController : GenericController<StoreOrderItem>
    {
        public StoreOrderItemsController(IMediator _mediator, IServiceGeneric<StoreOrderItem> _service) : base(_mediator, _service)
        {

        }
    }

    public class StoreProductsController : GenericController<StoreProduct>
    {
        public StoreProductsController(IMediator _mediator, IServiceGeneric<StoreProduct> _service) : base(_mediator, _service)
        {

        }
    }

    */


}
