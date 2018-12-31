using System;
using RochelleShared.Models;

namespace RochelleServer.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company> { }
    public interface ICustomerRepository : IGenericRepository<Customer> { }
    public interface IInviteRepository : IGenericRepository<Invite> { }
    public interface ILoginRepository : IGenericRepository<Login> { }
    public interface IParamConfigurationRepository : IGenericRepository<ParamConfiguration> { }
    public interface IPointExtractRepository : IGenericRepository<PointExtract> { }
    public interface IPointRuleRepository : IGenericRepository<PointRule> { }
    public interface IProductRepository : IGenericRepository<Product> { }
    public interface IStoreOrderRepository : IGenericRepository<StoreOrder> { }
    public interface IStoreOrderItemRepository : IGenericRepository<StoreOrderItem> { }
    public interface IStoreOrderStatusRepository : IGenericRepository<StoreOrderStatus> { }
    public interface IStoreProductRepository : IGenericRepository<StoreProduct> { }
}
