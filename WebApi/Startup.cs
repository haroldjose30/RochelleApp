using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MediatR;
using System.Reflection;
using ApplicationBusiness.Companies.CommandHandlers;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Infrastructure;
using Framework.Core.Notifications;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // .NET Native DI Abstraction
            RegisterServices(services);
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Rochelle Server API", Version = "v1" });
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                  //.... rest of app configuration
                app.UseSwaggerDocumentation();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           //app.UseHttpsRedirection();
            app.UseMvc();
        }

         private static void RegisterServices(IServiceCollection services)
        {
               //JsonWebTokenExtensions.Configure(services, Configuration);

            //... rest of services configuration
            services.AddSwaggerDocumentation();

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
    }
}
