
using Framework.NetCore.Contexts;
using Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
       
        public static void RegisterServices(IServiceCollection services)
        {
            //add class to Dependence Injector
            //services.AddDbContext<DbSqlContext>();
            services.AddScoped<IDbContextGeneric, DbContextGeneric>();
            ApplicationBusiness.Services.AllServices.AddServicesToDI(services);
            ApplicationBusiness.Validators.AllValidators.AddValidatorsToDI(services);
            Infra.Data.Repositories.AllRepositories.AddRepositoriesToDI(services);
        }
    }
}