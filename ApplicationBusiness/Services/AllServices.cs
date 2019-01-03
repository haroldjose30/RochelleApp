using Domain.Generals;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetStd.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationBusiness.Services
{
    public class AllServices
    {
        public static void AddServicesToDI(IServiceCollection services)
        {
            services.AddScoped<IServiceGeneric<User>, ServiceGeneric<User>>();
            services.AddScoped<IServiceGeneric<Company>, ServiceGeneric<Company>>();
            services.AddScoped<IServiceGeneric<Customer>, ServiceGeneric<Customer>>();
            services.AddScoped<IServiceGeneric<Invite>, ServiceGeneric<Invite>>();
            services.AddScoped<IServiceGeneric<ParamConfiguration>, ServiceGeneric<ParamConfiguration>>();
            services.AddScoped<IServiceGeneric<PointExtract>, ServiceGeneric<PointExtract>>();
            services.AddScoped<IServiceGeneric<PointRule>, ServiceGeneric<PointRule>>();
            services.AddScoped<IServiceGeneric<Product>, ServiceGeneric<Product>>();
            services.AddScoped<IServiceGeneric<StoreOrder>, ServiceGeneric<StoreOrder>>();
            services.AddScoped<IServiceGeneric<StoreOrderStatus>, ServiceGeneric<StoreOrderStatus>>();
            services.AddScoped<IServiceGeneric<StoreOrderItem>, ServiceGeneric<StoreOrderItem>>();
            services.AddScoped<IServiceGeneric<StoreProduct>, ServiceGeneric<StoreProduct>>();



        }
    }

    /*
    public class UserService : Service<User>
    {
        public UserService(UserRepository _repository, UserValidator _validator) : base(_repository, _validator)
        {

        }
    }
    */

        }

