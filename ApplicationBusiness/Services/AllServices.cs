using System;
using ApplicationBusiness.Validators;
using Domain.Models;
using Infra.Data.Repositories;
using Infra.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationBusiness.Services
{
    public class AllServices
    {
        public static void AddServicesToDI(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<CompanyService>();
            /*
            services.AddScoped<CustomerService>();
            services.AddScoped<InviteService>();
            services.AddScoped<ParamConfigurationService>();
            services.AddScoped<PointExtractService>();
            services.AddScoped<PointRuleService>();
            services.AddScoped<ProductService>();
            services.AddScoped<StoreOrderService>();
            services.AddScoped<StoreOrderStatusService>();
            services.AddScoped<StoreOrderItemService>();
            services.AddScoped<StoreProductService>();
            */
        }
    }

    public class UserService : Service<User>
    {
        public UserService(UserRepository _repository, UserValidator _validator) : base(_repository, _validator)
        {

        }
    }

    public class CompanyService : Service<Company>
    {
        public CompanyService(CompanyRepository _repository, CompanyValidator _validator) : base(_repository, _validator)
        {
        }
    }


    /*
    public class CustomerService : Service<Customer> { }
    public class InviteService : Service<Invite> { }
    public class ParamConfigurationService : Service<ParamConfiguration> { }
    public class PointExtractService : Service<PointExtract> { }
    public class PointRuleService : Service<PointRule> { }
    public class ProductService : Service<Product> { }
    public class StoreOrderService : Service<StoreOrder> { }
    public class StoreOrderItemService : Service<StoreOrderItem> { }
    public class StoreOrderStatusService : Service<StoreOrderStatus> { }
    public class StoreProductService : Service<StoreProduct> { }
    */
}
