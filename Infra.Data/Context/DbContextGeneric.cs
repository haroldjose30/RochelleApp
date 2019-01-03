//referencia
//https://medium.com/@alexalves_85598/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686

using System.Threading;
using System.Threading.Tasks;
using Domain.Generals;
using Domain.PointsManager;
using Domain.Store;
using Framework.NetCore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public partial class DbContextGeneric : DbContext, IDbContextGeneric
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ParamConfiguration> ParamConfigurations { get; set; }
        public DbSet<PointExtract> PointExtracts { get; set; }
        public DbSet<PointRule> PointRules { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreOrder> StoreOrders { get; set; }
        public DbSet<StoreOrderItem> StoreOrderItems { get; set; }
        public DbSet<StoreOrderStatus> StoreOrderStatus { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }




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
