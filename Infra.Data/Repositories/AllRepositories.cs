using System;
using Microsoft.Extensions.DependencyInjection;
using Domain.Models;
using Infra.Data.Repositories.Base;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{


    public class AllRepositories
    {
        public static void AddRepositoriesToDI(IServiceCollection services)
        {

            services.AddScoped<CompanyRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<InviteRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ParamConfigurationRepository>();
            services.AddScoped<PointExtractRepository>();
            services.AddScoped<PointRuleRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<StoreOrderRepository>();
            services.AddScoped<StoreOrderStatusRepository>();
            services.AddScoped<StoreOrderItemRepository>();
            services.AddScoped<StoreProductRepository>();
            /*

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IParamConfigurationRepository, ParamConfigurationRepository>();
            services.AddScoped<IPointExtractRepository, PointExtractRepository>();
            services.AddScoped<IPointRuleRepository, PointRuleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreOrderRepository, StoreOrderRepository>();
            services.AddScoped<IStoreOrderStatusRepository, StoreOrderStatusRepository>();
            services.AddScoped<IStoreOrderItemRepository, StoreOrderItemRepository>();
            services.AddScoped<IStoreProductRepository, StoreProductRepository>();
            */           
        }
    }

    public class CompanyRepository : Repository<Company>//, ICompanyRepository
    {
        public CompanyRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class CustomerRepository : RepositoryWithCompany<Customer>//, ICustomerRepository
    {
        public CustomerRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class InviteRepository : RepositoryWithCompany<Invite>//, IInviteRepository
    {
        public InviteRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class UserRepository : RepositoryWithCompany<User>//, IUserRepository
    {
        public UserRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class ParamConfigurationRepository : RepositoryWithCompany<ParamConfiguration>//, IParamConfigurationRepository
    {
        public ParamConfigurationRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class PointExtractRepository : RepositoryWithCompany<PointExtract>//, IPointExtractRepository
    {
        public PointExtractRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class PointRuleRepository : RepositoryWithCompany<PointRule>//, IPointRuleRepository
    {
        public PointRuleRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class ProductRepository : RepositoryWithCompany<Product>//, IProductRepository
    {
        public ProductRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreOrderRepository : RepositoryWithCompany<StoreOrder>//, IStoreOrderRepository
    {
        public StoreOrderRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreOrderItemRepository : RepositoryWithCompany<StoreOrderItem>//, IStoreOrderItemRepository
    {
        public StoreOrderItemRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreOrderStatusRepository : Repository<StoreOrderStatus>//, IStoreOrderStatusRepository
    {
        public StoreOrderStatusRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class StoreProductRepository : RepositoryWithCompany<StoreProduct>//, IStoreProductRepository
    {
        public StoreProductRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }
}
