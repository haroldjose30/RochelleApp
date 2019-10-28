using System;
using Domain.Generals;
using Domain.Identity;
using Domain.PointsManager;
using Domain.Store;
using Framework.Core.Interfaces;
using Infra.Data.Repositories.Base;

namespace Infra.Data.Repositories
{
    public interface ICompanyRepository : IRepository<Company> { }
    /*
    public interface ICustomerRepository : IRepositoryWithCompany<Customer> { }
    public interface IInviteRepository : IRepositoryWithCompany<Invite> { }
    public interface IUserRepository : IRepositoryWithCompany<User> { }
    public interface IParamConfigurationRepository : IRepositoryWithCompany<ParamConfiguration> { }
    public interface IPointExtractRepository : IRepositoryWithCompany<PointExtract> { }
    public interface IPointRuleRepository : IRepositoryWithCompany<PointRule> { }
    public interface IProductRepository : IRepositoryWithCompany<Product> { }
    public interface IStoreOrderRepository : IRepositoryWithCompany<StoreOrder> { }
    public interface IStoreOrderItemRepository : IRepositoryWithCompany<StoreOrderItem> { }
    public interface IStoreOrderStatusRepository : IRepository<StoreOrderStatus> { }
    public interface IStoreProductRepository : IRepositoryWithCompany<StoreProduct> { }
    */
}
