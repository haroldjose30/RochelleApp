using Domain.Generals;
using Domain.PointsManager;
using Domain.Store;
using Framework.Core.Notifications;
using Framework.Core.Services;
using MediatR;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{

    public class CustomersController : GenericController<Customer>
    {
        public CustomersController(IGenericService<Customer> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class CompaniesController : GenericController<Company>
    {
        public CompaniesController(IGenericService<Company> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }


    public class InvitesController : GenericController<Invite>
    {
        public InvitesController(IGenericService<Invite> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }


    public class ParamConfigurationsController : GenericController<ParamConfiguration>
    {
        public ParamConfigurationsController(IGenericService<ParamConfiguration> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class PointAccountController : GenericController<PointAccount>
    {
        public PointAccountController(IGenericService<PointAccount> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class PointCustomerController : GenericController<PointCustomer>
    {
        public PointCustomerController(IGenericService<PointCustomer> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }



    public class PointAccountDetailController : GenericController<PointAccountDetail>
    {
        public PointAccountDetailController(IGenericService<PointAccountDetail> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class PointRulesController : GenericController<PointRule>
    {
        public PointRulesController(IGenericService<PointRule> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class ProductsController : GenericController<Product>
    {
        public ProductsController(IGenericService<Product> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }


    public class StoreOrdersController : GenericController<StoreOrder>
    {
        public StoreOrdersController(IGenericService<StoreOrder> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }


    public class StoreOrderStatusController : GenericController<StoreOrderStatus>
    {
        public StoreOrderStatusController(IGenericService<StoreOrderStatus> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class StoreOrderItemsController : GenericController<StoreOrderItem>
    {
        public StoreOrderItemsController(IGenericService<StoreOrderItem> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }

    public class StoreProductsController : GenericController<StoreProduct>
    {
        public StoreProductsController(IGenericService<StoreProduct> _service, INotificationHandler<DomainNotification> notifications) : base(_service, notifications)
        {
        }
    }




}
