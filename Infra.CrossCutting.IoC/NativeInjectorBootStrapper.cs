
using Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //add class to Dependence Injector
            services.AddDbContext<DbSqlContext>();
            ApplicationBusiness.Validators.AllValidators.AddValidatorsToDI(services);
            ApplicationBusiness.Services.AllServices.AddServicesToDI(services);
            Infra.Data.Repositories.AllRepositories.AddRepositoriesToDI(services);
        }
    }
}