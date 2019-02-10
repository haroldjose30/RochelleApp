using System.Reflection;
using Domain.Generals.Companies.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Infrastructure;
using Microsoft.Extensions.Logging;
using Domain.Core.CommandHandlers;
using Domain.Core.Models;
using Domain.Generals;
using Domain.Core.Commands;

namespace WebApi
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


           //JsonWebTokenExtensions.Configure(services, Configuration);

            //... rest of services configuration
            services.AddSwaggerDocumentation();

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

                _logger.LogInformation("In Development environment");
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

          
            app.UseHttpsRedirection();
            app.UseMvc();

           
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            Infra.CrossCutting.IoC.NativeInjectorBootStrapper.RegisterServices(services);
            ConfigureMediatR(services);
        }

        public static void ConfigureMediatR(IServiceCollection services)
        {
            // if you have handlers/events in other assemblies
            services.AddMediatR(
                                    typeof(Startup).GetTypeInfo().Assembly,
                                    typeof(Command).GetTypeInfo().Assembly,
                                     typeof(RegisterNewCompanyCommandHandler).GetTypeInfo().Assembly,
                                    typeof(RegisterNewGenericCommandHandler<Entity>).GetTypeInfo().Assembly
                                 );

        }




    }

   
}
