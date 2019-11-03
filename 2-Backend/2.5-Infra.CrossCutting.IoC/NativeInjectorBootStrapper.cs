using ApplicationBusiness.Authentication;
using ApplicationBusiness.Companies.Validations;
using Domain.Generals;
using Domain.Identity;
using Framework.Core.Interfaces;
using Framework.Core.Services;
using Infra.CrossCutting.Bus;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Infra.Data.Repositories.Base;
using Infra.Data.UoW;
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

            AddServicesToDi(services);
            AddValidatorsToDi(services);
            AddRepositoriesToDi(services);

            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

           
            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();
   }



        public static void AddRepositoriesToDi(IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IRepository<Company>, Repository<Company>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
        }

        public static void AddValidatorsToDi(IServiceCollection services)
        {
            services.AddScoped<IRegisterNewGenericCommandValidation<Company>, RegisterNewCompanyCommandValidation>();
        }

        public static void AddServicesToDi(IServiceCollection services)
        {

            services.AddScoped<IGenericService<Company>, GenericService<Company>>();
            services.AddScoped<IGenericService<User>, GenericService<User>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
         
        }

    }

   

   


  
}