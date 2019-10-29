
using Domain.Generals;
using Domain.Identity;
using Domain.PointsManager;
using Domain.Store;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Infra.Data.Context
{
    public class DbContextGeneric : DbContext//,IDbContextGeneric
    {

       // public static readonly LoggerFactory EFLoggerFactory
       //     = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<Company> Companies { get; private set; }

        public DbSet<Customer> Customers { get; private set; }
        public DbSet<ParamConfiguration> ParamConfigurations { get; private set; }
        public DbSet<Product> Products { get; private set; }

        public DbSet<User> Users { get; private set; }

        public DbSet<Invite> Invites { get; private set; }
        public DbSet<PointAccount> PointAccounts { get; private set; }
        public DbSet<PointAccountDetail> PointAccountDetails { get; private set; }
        public DbSet<PointCustomer> PointCustomers { get; private set; }
        public DbSet<PointRule> PointRules { get; private set; }

        public DbSet<StoreOrder> StoreOrders { get; private set; }
        public DbSet<StoreOrderItem> StoreOrderItems { get; private set; }
        public DbSet<StoreOrderStatus> StoreOrderStatus { get; private set; }
        public DbSet<StoreProduct> StoreProducts { get; private set; }
             

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=45.79.205.99;User Id=app;Password=MeuAmorzinho2019@;Database=RochelleDb_Dev");
            }

            //optionsBuilder.UseLoggerFactory(EFLoggerFactory); // Warning: Do not create a new ILoggerFactory instance each time


            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
        }
    }
}
