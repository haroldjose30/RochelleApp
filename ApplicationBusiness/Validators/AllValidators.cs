using Domain.Generals;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetStd.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationBusiness.Validators
{
    public class AllValidators
    {
        public static void AddValidatorsToDI(IServiceCollection services)
        {
            services.AddScoped<IValidatorGeneric<User>, UserValidator>();
            services.AddScoped<IValidatorGeneric<Company>, CompanyValidator>();

            services.AddScoped<IValidatorGeneric<Customer>, CustomerValidator >();
            services.AddScoped<IValidatorGeneric<Invite>, InviteValidator>();
            services.AddScoped<IValidatorGeneric<ParamConfiguration>, ParamConfigurationValidator>();
            services.AddScoped<IValidatorGeneric<PointExtract>, PointExtractValidator>();
            services.AddScoped<IValidatorGeneric<PointRule>, PointRuleValidator >();
            services.AddScoped<IValidatorGeneric<Product>, ProductValidator>();
            services.AddScoped<IValidatorGeneric<StoreOrder>, StoreOrderValidator>();
            services.AddScoped<IValidatorGeneric<StoreOrderStatus>, StoreOrderStatusValidator>();
            services.AddScoped<IValidatorGeneric<StoreOrderItem>, StoreOrderItemValidator>();
            services.AddScoped<IValidatorGeneric<StoreProduct>, StoreProductValidator>();
        }
    }

    public class CompanyValidator : ValidatorGeneric<Company> { };
    public class CustomerValidator : ValidatorGeneric<Customer> { };
    public class InviteValidator : ValidatorGeneric<Invite> { };
    public class ParamConfigurationValidator : ValidatorGeneric<ParamConfiguration> { };
    public class PointExtractValidator : ValidatorGeneric<PointExtract> { };
    public class PointRuleValidator : ValidatorGeneric<PointRule> { };
    public class ProductValidator : ValidatorGeneric<Product> { };
    public class StoreOrderValidator : ValidatorGeneric<StoreOrder> { };
    public class StoreOrderStatusValidator : ValidatorGeneric<StoreOrderStatus> { };
    public class StoreOrderItemValidator : ValidatorGeneric<StoreOrderItem> { };
    public class StoreProductValidator : ValidatorGeneric<StoreProduct> { };




}