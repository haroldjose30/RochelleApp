
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

            services.AddScoped<IRepositoryGeneric<Company>, RepositoryGeneric<Company>>();
            services.AddScoped<IRepositoryGeneric<Customer>,RepositoryGeneric<Customer>>();
            services.AddScoped<IRepositoryGeneric<Invite>, RepositoryGeneric<Invite>>();
            services.AddScoped<IRepositoryGeneric<User>, RepositoryGeneric<User>>();
            services.AddScoped<IRepositoryGeneric<ParamConfiguration>, RepositoryGeneric<ParamConfiguration>>();
            services.AddScoped<IRepositoryGeneric<PointAccountDetail>, RepositoryGeneric<PointAccountDetail>>();
            services.AddScoped<IRepositoryGeneric<PointRule>, RepositoryGeneric<PointRule>>();
            services.AddScoped<IRepositoryGeneric<Product>, RepositoryGeneric<Product>>();
            services.AddScoped<IRepositoryGeneric<StoreOrder>, RepositoryGeneric<StoreOrder>>();
            services.AddScoped<IRepositoryGeneric<StoreOrderStatus>, RepositoryGeneric<StoreOrderStatus>>();
            services.AddScoped<IRepositoryGeneric<StoreOrderItem>, RepositoryGeneric<StoreOrderItem>>();
            services.AddScoped<IRepositoryGeneric<StoreProduct>, RepositoryGeneric<StoreProduct>>();

          
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

