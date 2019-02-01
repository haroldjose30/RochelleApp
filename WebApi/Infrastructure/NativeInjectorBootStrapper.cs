
using System.Reflection;
using Domain.Core.Interfaces;
using Domain.Generals;
using Domain.Generals.Companies.Validations;
using Domain.Identity;
using Domain.PointsManager;
using Domain.Store;
using Domain.Validators;
using Framework.NetCore.Contexts;
using Framework.NetStd.Services;
using Framework.NetStd.Validators;
using Infra.Data.Context;
using Infra.Data.Repositories.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WebApi;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
       
        public static void RegisterServices(IServiceCollection services)
        {
            //add class to Dependence Injector
            //services.AddDbContext<DbSqlContext>();
            services.AddScoped<IDbContextGeneric, DbContextGeneric>();
            AddServicesToDI(services);
            AddValidatorsToDI(services);
            AddRepositoriesToDI(services);
            ConfigureMediatR(services);
        }


        public static void ConfigureMediatR(IServiceCollection services)
        {
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.MeasureTime<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.ValidateCommand<,>));

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }

        public static void AddRepositoriesToDI(IServiceCollection services)
        {

            services.AddScoped<IRepositoryGeneric<Company>, GenericRepository<Company>>();
            services.AddScoped<IRepositoryGeneric<Customer>, GenericRepository<Customer>>();
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

        public static void AddValidatorsToDI(IServiceCollection services)
        {
            services.AddScoped<IValidatorGeneric<User>, UserValidator>();
            //services.AddScoped<IValidatorGeneric<Company>, CompanyValidation>();

            services.AddScoped<IValidatorGeneric<Customer>, CustomerValidator>();
            services.AddScoped<IValidatorGeneric<Invite>, InviteValidator>();
            services.AddScoped<IValidatorGeneric<ParamConfiguration>, ParamConfigurationValidator>();
            services.AddScoped<IValidatorGeneric<PointAccount>, PointAccountValidator>();
            services.AddScoped<IValidatorGeneric<PointCustomer>, PointCustomerValidator>();
            services.AddScoped<IValidatorGeneric<PointAccountDetail>, PointAccountDetailValidator>();
            services.AddScoped<IValidatorGeneric<PointRule>, PointRuleValidator>();
            services.AddScoped<IValidatorGeneric<Product>, ProductValidator>();
            services.AddScoped<IValidatorGeneric<StoreOrder>, StoreOrderValidator>();
            services.AddScoped<IValidatorGeneric<StoreOrderStatus>, StoreOrderStatusValidator>();
            services.AddScoped<IValidatorGeneric<StoreOrderItem>, StoreOrderItemValidator>();
            services.AddScoped<IValidatorGeneric<StoreProduct>, StoreProductValidator>();
        }

        public static void AddServicesToDI(IServiceCollection services)
        {
            services.AddScoped<IServiceGeneric<User>, ServiceGeneric<User>>();
            services.AddScoped<IServiceGeneric<Company>, ServiceGeneric<Company>>();
            services.AddScoped<IServiceGeneric<Customer>, ServiceGeneric<Customer>>();
            services.AddScoped<IServiceGeneric<Invite>, ServiceGeneric<Invite>>();
            services.AddScoped<IServiceGeneric<ParamConfiguration>, ServiceGeneric<ParamConfiguration>>();
            services.AddScoped<IServiceGeneric<PointAccount>, ServiceGeneric<PointAccount>>();
            services.AddScoped<IServiceGeneric<PointAccountDetail>, ServiceGeneric<PointAccountDetail>>();
            services.AddScoped<IServiceGeneric<PointCustomer>, ServiceGeneric<PointCustomer>>();
            services.AddScoped<IServiceGeneric<PointRule>, ServiceGeneric<PointRule>>();
            services.AddScoped<IServiceGeneric<Product>, ServiceGeneric<Product>>();
            services.AddScoped<IServiceGeneric<StoreOrder>, ServiceGeneric<StoreOrder>>();
            services.AddScoped<IServiceGeneric<StoreOrderStatus>, ServiceGeneric<StoreOrderStatus>>();
            services.AddScoped<IServiceGeneric<StoreOrderItem>, ServiceGeneric<StoreOrderItem>>();
            services.AddScoped<IServiceGeneric<StoreProduct>, ServiceGeneric<StoreProduct>>();



        }

    }

   

   


  
}