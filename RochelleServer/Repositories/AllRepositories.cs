using System;
using Microsoft.Extensions.DependencyInjection;
using RochelleShared.Models;

namespace RochelleServer.Repositories
{


    public class AllRepositories
    {
        public static void AddRepositoriesToDI(IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IParamConfigurationRepository, ParamConfigurationRepository>();
            services.AddScoped<IPointExtractRepository, PointExtractRepository>();
            services.AddScoped<IPointRuleRepository, PointRuleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreOrderRepository, StoreOrderRepository>();
            services.AddScoped<IStoreOrderStatusRepository, StoreOrderStatusRepository>();
            services.AddScoped<IStoreOrderItemRepository, StoreOrderItemRepository>();
            services.AddScoped<IStoreProductRepository, StoreProductRepository>();
        }
    }

    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class InviteRepository : GenericRepository<Invite>, IInviteRepository
    {
        public InviteRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class ParamConfigurationRepository : GenericRepository<ParamConfiguration>, IParamConfigurationRepository
    {
        public ParamConfigurationRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class PointExtractRepository : GenericRepository<PointExtract>, IPointExtractRepository
    {
        public PointExtractRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class PointRuleRepository : GenericRepository<PointRule>, IPointRuleRepository
    {
        public PointRuleRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreOrderRepository : GenericRepository<StoreOrder>, IStoreOrderRepository
    {
        public StoreOrderRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreOrderItemRepository : GenericRepository<StoreOrderItem>, IStoreOrderItemRepository
    {
        public StoreOrderItemRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreOrderStatusRepository : GenericRepository<StoreOrderStatus>, IStoreOrderStatusRepository
    {
        public StoreOrderStatusRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreProductRepository : GenericRepository<StoreProduct>, IStoreProductRepository
    {
        public StoreProductRepository(RochelleDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
