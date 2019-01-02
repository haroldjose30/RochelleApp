﻿// <auto-generated />
using System;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(DbSqlContext))]
    [Migration("20190102073348_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Company", b =>
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

                    b.Property<string>("Dristrict");

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

            modelBuilder.Entity("Domain.Models.Customer", b =>
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

            modelBuilder.Entity("Domain.Models.Invite", b =>
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

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<int>("InviteStatus");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerFromId");

                    b.HasIndex("CustomerToId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Domain.Models.ParamConfiguration", b =>
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

            modelBuilder.Entity("Domain.Models.PointExtract", b =>
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

                    b.Property<int>("PointExtractType");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("PointExtracts");
                });

            modelBuilder.Entity("Domain.Models.PointRule", b =>
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

            modelBuilder.Entity("Domain.Models.Product", b =>
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

            modelBuilder.Entity("Domain.Models.StoreOrder", b =>
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

            modelBuilder.Entity("Domain.Models.StoreOrderItem", b =>
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

                    b.Property<double>("Quantity");

                    b.Property<string>("StoreOrderId");

                    b.Property<double>("ValuePoint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreOrderId");

                    b.ToTable("StoreOrderItems");
                });

            modelBuilder.Entity("Domain.Models.StoreOrderStatus", b =>
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

            modelBuilder.Entity("Domain.Models.StoreProduct", b =>
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

                    b.Property<double>("ValuePoint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProductId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
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

            modelBuilder.Entity("Domain.Models.Customer", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Models.Invite", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Customer", "CustomerFrom")
                        .WithMany()
                        .HasForeignKey("CustomerFromId");

                    b.HasOne("Domain.Models.Customer", "CustomerTo")
                        .WithMany()
                        .HasForeignKey("CustomerToId");
                });

            modelBuilder.Entity("Domain.Models.ParamConfiguration", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Models.PointExtract", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Domain.Models.PointRule", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.Models.StoreOrder", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Customer", "CustomerFrom")
                        .WithMany()
                        .HasForeignKey("CustomerFromId");

                    b.HasOne("Domain.Models.StoreOrderStatus", "StoreOrderStatus")
                        .WithMany()
                        .HasForeignKey("StoreOrderStatusId");
                });

            modelBuilder.Entity("Domain.Models.StoreOrderItem", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.StoreProduct", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Domain.Models.StoreOrder")
                        .WithMany("Items")
                        .HasForeignKey("StoreOrderId");
                });

            modelBuilder.Entity("Domain.Models.StoreProduct", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}