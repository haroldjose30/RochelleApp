﻿// <auto-generated />
using System;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(DbContextGeneric))]
    [Migration("20190111213655_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Generals.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Complement");

                    b.Property<string>("CorporateNumber");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("District");

                    b.Property<string>("FantasyName");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<string>("StateRegistration");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Generals.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Document");

                    b.Property<string>("Email");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Generals.ParamConfiguration", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("ParamConfigurations");
                });

            modelBuilder.Entity("Domain.Generals.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("ProductType");

                    b.Property<int>("RegisterState");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<string>("CustomerId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.PointsManager.Invite", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<string>("CustomerFromId");

                    b.Property<string>("CustomerToId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<int>("InviteStatus");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerFromId");

                    b.HasIndex("CustomerToId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Domain.PointsManager.PointAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<string>("CustomerId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("PointAccounts");
                });

            modelBuilder.Entity("Domain.PointsManager.PointAccountDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Document");

                    b.Property<DateTime?>("Expiration");

                    b.Property<string>("History");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("PointAccountId");

                    b.Property<int>("PointExtractType");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PointAccountId");

                    b.ToTable("PointAccountDetails");
                });

            modelBuilder.Entity("Domain.PointsManager.PointCustomer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<string>("CustomerId");

                    b.Property<bool>("Deleted");

                    b.Property<int>("InvitesQuantity");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("PointCustomers");
                });

            modelBuilder.Entity("Domain.PointsManager.PointRule", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("PointRuleType");

                    b.Property<double>("PointToGain");

                    b.Property<int>("RegisterState");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("PointRules");
                });

            modelBuilder.Entity("Domain.Store.StoreOrder", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<string>("CustomerFromId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("StoreOrderStatusId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerFromId");

                    b.HasIndex("StoreOrderStatusId");

                    b.ToTable("StoreOrders");
                });

            modelBuilder.Entity("Domain.Store.StoreOrderItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("ProductId");

                    b.Property<decimal>("Quantity");

                    b.Property<string>("StoreOrderId");

                    b.Property<decimal>("ValuePoint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreOrderId");

                    b.ToTable("StoreOrderItems");
                });

            modelBuilder.Entity("Domain.Store.StoreOrderStatus", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int>("Sequence");

                    b.HasKey("Id");

                    b.ToTable("StoreOrderStatus");
                });

            modelBuilder.Entity("Domain.Store.StoreProduct", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.Property<string>("ProductId");

                    b.Property<int>("RegisterState");

                    b.Property<decimal>("ValueMoney");

                    b.Property<decimal>("ValuePoint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("Domain.Generals.Customer", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Generals.ParamConfiguration", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Generals.Product", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Identity.User", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Domain.PointsManager.Invite", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Customer", "CustomerFrom")
                        .WithMany()
                        .HasForeignKey("CustomerFromId");

                    b.HasOne("Domain.Generals.Customer", "CustomerTo")
                        .WithMany()
                        .HasForeignKey("CustomerToId");
                });

            modelBuilder.Entity("Domain.PointsManager.PointAccount", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Domain.PointsManager.PointAccountDetail", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Domain.PointsManager.PointAccount")
                        .WithMany("Items")
                        .HasForeignKey("PointAccountId");
                });

            modelBuilder.Entity("Domain.PointsManager.PointCustomer", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Domain.PointsManager.PointRule", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Store.StoreOrder", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Customer", "CustomerFrom")
                        .WithMany()
                        .HasForeignKey("CustomerFromId");

                    b.HasOne("Domain.Store.StoreOrderStatus", "StoreOrderStatus")
                        .WithMany()
                        .HasForeignKey("StoreOrderStatusId");
                });

            modelBuilder.Entity("Domain.Store.StoreOrderItem", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Store.StoreProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Domain.Store.StoreOrder", "StoreOrder")
                        .WithMany("Items")
                        .HasForeignKey("StoreOrderId");
                });

            modelBuilder.Entity("Domain.Store.StoreProduct", b =>
                {
                    b.HasOne("Domain.Generals.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Generals.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
