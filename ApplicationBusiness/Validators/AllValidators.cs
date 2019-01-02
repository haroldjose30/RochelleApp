using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationBusiness.Validators
{
    public class AllValidators
    {
        public static void AddValidatorsToDI(IServiceCollection services)
        {
            services.AddScoped<CompanyValidator>();
            services.AddScoped<CustomerValidator>();
            services.AddScoped<InviteValidator>();
            services.AddScoped<UserValidator>();
            services.AddScoped<ParamConfigurationValidator>();
            services.AddScoped<PointExtractValidator>();
            services.AddScoped<PointRuleValidator>();
            services.AddScoped<ProductValidator>();
            services.AddScoped<StoreOrderValidator>();
            services.AddScoped<StoreOrderStatusValidator>();
            services.AddScoped<StoreOrderItemValidator>();
            services.AddScoped<StoreProductValidator>();
        }
    }

    public class CompanyValidator : Validator<Company> { }
    public class CustomerValidator : Validator<Customer> { }
    public class InviteValidator : Validator<Invite> { }
    public class ParamConfigurationValidator : Validator<ParamConfiguration> { }
    public class PointExtractValidator : Validator<PointExtract> { }
    public class PointRuleValidator : Validator<PointRule> { }
    public class ProductValidator : Validator<Product> { }
    public class StoreOrderValidator : Validator<StoreOrder> { }
    public class StoreOrderItemValidator : Validator<StoreOrderItem> { }
    public class StoreOrderStatusValidator : Validator<StoreOrderStatus> { }
    public class StoreProductValidator : Validator<StoreProduct> { }

}
