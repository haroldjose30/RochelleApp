using ApplicationBusiness.Authentication;
using ApplicationBusiness.Companies.CommandHandlers;
using ApplicationBusiness.Companies.Validations;
using Domain.Generals;
using Domain.Identity;
using Framework.Core.CommandHandlers;
using Framework.Core.Commands;
using Framework.Core.EventHandlers;
using Framework.Core.Events;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Notifications;
using Framework.Core.Services;
using Infra.CrossCutting.Bus;
using Infra.Data.Context;
using Infra.Data.Repositories;
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
            //OBS: dont register DomainNotificationHandler automatic, only in scoped section like above
            //this very important because we need only one instance por request (Scoped)
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();



            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //Company Services
            services.AddScoped<IGenericService<Company>, GenericService<Company>>();
            
            //Company Command Handlers
            services.AddScoped<IRequestHandler<CreateGenericCommand<Company>, Unit>, CreateCompanyCommandHandler>();
            //services.AddScoped<IRequestHandler<CreateGenericCommand<Company>,Unit>, CreateGenericCommandHandler<Company>>();
            services.AddScoped<IRequestHandler<UpdateGenericCommand<Company>, Unit>, UpdateGenericCommandHandler<Company>>();
            services.AddScoped<IRequestHandler<DeleteGenericCommand<Company>, Unit>, DeleteGenericCommandHandler<Company>>();
    
            //Company Event Handlers
            services.AddScoped<INotificationHandler<CreatedGenericEvent<Company>>, CreatedGenericEventHandler<Company>>();
            services.AddScoped<INotificationHandler<UpdatedGenericEvent<Company>>, UpdatedGenericEventHandler<Company>>();
            services.AddScoped<INotificationHandler<DeletedGenericEvent<Company>>, DeletedGenericEventHandler<Company>>();
            
            //Company repository
            services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();
        
            
            
            services.RegisterGenericCrudInterfaces<Customer>();
            services.RegisterGenericCrudInterfaces<ParamConfiguration>();
            services.RegisterGenericCrudInterfaces<Product>();
            services.RegisterGenericCrudInterfaces<User>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserGenericRepository, UserGenericRepository>();
        }

       
    }
    
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterGenericCrudInterfaces<TEntity>(this IServiceCollection services)  where TEntity:Entity, new()
        {
            //services
            services.AddScoped<IGenericService<TEntity>, GenericService<TEntity>>();
            //Command Handlers
            services.AddScoped<IRequestHandler<CreateGenericCommand<TEntity>,Unit>, CreateGenericCommandHandler<TEntity>>();
            services.AddScoped<IRequestHandler<UpdateGenericCommand<TEntity>, Unit>, UpdateGenericCommandHandler<TEntity>>();
            services.AddScoped<IRequestHandler<DeleteGenericCommand<TEntity>, Unit>, DeleteGenericCommandHandler<TEntity>>();
            //Event Handlers
            services.AddScoped<INotificationHandler<CreatedGenericEvent<TEntity>>, CreatedGenericEventHandler<TEntity>>();
            services.AddScoped<INotificationHandler<UpdatedGenericEvent<TEntity>>, UpdatedGenericEventHandler<TEntity>>();
            services.AddScoped<INotificationHandler<DeletedGenericEvent<TEntity>>, DeletedGenericEventHandler<TEntity>>();
            //repository
            services.AddScoped<IGenericRepository<TEntity>, GenericRepository<TEntity>>();
            return services;
        }
    }
}



