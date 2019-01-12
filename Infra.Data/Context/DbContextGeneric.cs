//referencia
//https://medium.com/@alexalves_85598/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686

using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Domain.Identity;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public partial class DbContextGeneric : DbContext, IDbContextGeneric
    {
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
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=MeuAmorzinho2018@;Database=Rochelledb_dev");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
        }
    }
}
