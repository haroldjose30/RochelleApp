using System;
using Microsoft.EntityFrameworkCore;
using RochelleShared.Models;

namespace RochelleServer
{
    public partial class RochelleDbContext : DbContext
    {

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Login> Logins { get; set; }
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
