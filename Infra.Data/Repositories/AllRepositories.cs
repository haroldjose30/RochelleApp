
using Domain.Generals;
using Domain.Identity;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetStd.Repositories;
using Infra.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data.Repositories
{


    public class AllRepositories
    {
        public static void AddRepositoriesToDI(IServiceCollection services)
        {

            services.AddScoped<IRepositoryGeneric<Company>, GenericRepository<Company>>();
            services.AddScoped<IRepositoryGeneric<Customer>,GenericRepository<Customer>>();
            services.AddScoped<IRepositoryGeneric<Invite>, GenericRepository<Invite>>();
            services.AddScoped<IRepositoryGeneric<User>, GenericRepository<User>>();
            services.AddScoped<IRepositoryGeneric<ParamConfiguration>, GenericRepository<ParamConfiguration>>();
            services.AddScoped<IRepositoryGeneric<PointAccount>, GenericRepository<PointAccount>>();
            services.AddScoped<IRepositoryGeneric<PointCustomer>, GenericRepository<PointCustomer>>();
            services.AddScoped<IRepositoryGeneric<PointAccountDetail>, GenericRepository<PointAccountDetail>>();
            services.AddScoped<IRepositoryGeneric<PointRule>, GenericRepository<PointRule>>();
            services.AddScoped<IRepositoryGeneric<Product>, GenericRepository<Product>>();
            services.AddScoped<IRepositoryGeneric<StoreOrder>, GenericRepository<StoreOrder>>();
            services.AddScoped<IRepositoryGeneric<StoreOrderStatus>, GenericRepository<StoreOrderStatus>>();
            services.AddScoped<IRepositoryGeneric<StoreOrderItem>, GenericRepository<StoreOrderItem>>();
            services.AddScoped<IRepositoryGeneric<StoreProduct>, GenericRepository<StoreProduct>>();

          
        }
    }

    /*
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbSqlContext dbContext)
            : base(dbContext)
        {

        }
    }
    */

   
}

