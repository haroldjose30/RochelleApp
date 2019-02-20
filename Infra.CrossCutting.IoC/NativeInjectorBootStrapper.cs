using ApplicationBusiness.Companies.Validations;
using Domain.Generals;
using Domain.Identity;
using Domain.PointsManager;
using Domain.Store;
using Framework.Core.Interfaces;
using Framework.Core.Notifications;
using Framework.Core.Services;
using Framework.Core.Validations;
using Infra.CrossCutting.Bus;
using Infra.Data.Context;
using Infra.Data.Repositories.Base;
using Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
       
        public static void RegisterServices(IServiceCollection services)
        {
            //add class to Dependence Injector
            services.AddDbContext<DbContextGeneric>();
            //services.AddScoped<IDbContextGeneric, DbContextGeneric>();


            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            AddServicesToDI(services);
            AddValidatorsToDI(services);
            AddRepositoriesToDI(services);

            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            //services.AddScoped<ICustomerAppService, CustomerAppService>();



            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }



        public static void AddRepositoriesToDI(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IRepository<Company>, Repository<Company>>();
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<Invite>, Repository<Invite>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<ParamConfiguration>, Repository<ParamConfiguration>>();
            services.AddScoped<IRepository<PointAccount>, Repository<PointAccount>>();
            services.AddScoped<IRepository<PointCustomer>, Repository<PointCustomer>>();
            services.AddScoped<IRepository<PointAccountDetail>, Repository<PointAccountDetail>>();
            services.AddScoped<IRepository<PointRule>, Repository<PointRule>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<StoreOrder>, Repository<StoreOrder>>();
            services.AddScoped<IRepository<StoreOrderStatus>, Repository<StoreOrderStatus>>();
            services.AddScoped<IRepository<StoreOrderItem>, Repository<StoreOrderItem>>();
            services.AddScoped<IRepository<StoreProduct>, Repository<StoreProduct>>();

        }

        public static void AddValidatorsToDI(IServiceCollection services)
        {
            services.AddScoped<IRegisterNewGenericCommandValidation<Company>, RegisterNewCompanyCommandValidation>();
        }

        public static void AddServicesToDI(IServiceCollection services)
        {

            services.AddScoped<IGenericService<Company>, GenericService<Company>>();
            services.AddScoped<IGenericService<Customer>, GenericService<Customer>>();
            services.AddScoped<IGenericService<User>, GenericService<User>>();
            services.AddScoped<IGenericService<Invite>, GenericService<Invite>>();
            services.AddScoped<IGenericService<ParamConfiguration>, GenericService<ParamConfiguration>>();
            services.AddScoped<IGenericService<PointAccount>, GenericService<PointAccount>>();
            services.AddScoped<IGenericService<PointAccountDetail>, GenericService<PointAccountDetail>>();
            services.AddScoped<IGenericService<PointCustomer>, GenericService<PointCustomer>>();
            services.AddScoped<IGenericService<PointRule>, GenericService<PointRule>>();
            services.AddScoped<IGenericService<Product>, GenericService<Product>>();
            services.AddScoped<IGenericService<StoreOrder>, GenericService<StoreOrder>>();
            services.AddScoped<IGenericService<StoreOrderStatus>, GenericService<StoreOrderStatus>>();
            services.AddScoped<IGenericService<StoreOrderItem>, GenericService<StoreOrderItem>>();
            services.AddScoped<IGenericService<StoreProduct>, GenericService<StoreProduct>>();




        }

    }

   

   


  
}