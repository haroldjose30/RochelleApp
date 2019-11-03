using System.Reflection;
using ApplicationBusiness.Companies.CommandHandlers;
using Framework.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Jwt;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // .NET Native DI Abstraction
            RegisterServices(services);
            services.AddControllers()
                .AddNewtonsoftJson();



        }
        
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private void RegisterServices(IServiceCollection services)
        {
            JsonWebTokenExtensions.Configure(services, Configuration);
            
            //... rest of services configuration
            services.AddSwaggerDocumentation();
            
            
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                       
                    });
            });

            Infra.CrossCutting.IoC.NativeInjectorBootStrapper.RegisterServices(services);
            ConfigureMediatR(services);
        }
        
        public static void ConfigureMediatR(IServiceCollection services)
        {

            //OBS: dont register DomainNotificationHandler automatic, only in scoped section like above
            //this very important becouse we need only one instance por request (Scoped)
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // if you have handlers/events in other assemblies
            services.AddMediatR(
                typeof(Startup).GetTypeInfo().Assembly
                ,typeof(RegisterNewCompanyCommandHandler).GetTypeInfo().Assembly

            );


       


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
             
            }
            
            app.UseCors(MyAllowSpecificOrigins); 
            
         
            //.... rest of app configuration
            app.UseSwaggerDocumentation();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}