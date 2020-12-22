﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagement.Context;

namespace StockManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201222222047_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("StockManagement.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActiveProvider")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CompanyID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Company");
                });

            modelBuilder.Entity("StockManagement.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("SpaceOccupied")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StockManagement.Models.Stock", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("TotalCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("int");

                    b.HasKey("StockID");

                    b.HasIndex("ProductID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockManagement.Models.StockTransfer", b =>
                {
                    b.Property<int>("StockTransferID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromStockID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ToStockID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("StockTransferID");

                    b.HasIndex("FromStockID");

                    b.HasIndex("ProductID");

                    b.HasIndex("ToStockID");

                    b.ToTable("StockTransfers");
                });

            modelBuilder.Entity("StockManagement.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AvailableForTransfers")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<decimal>("StorageSpace")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("WarehouseID");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("StockManagement.Models.Product", b =>
                {
                    b.HasOne("StockManagement.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("StockManagement.Models.Stock", b =>
                {
                    b.HasOne("StockManagement.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockManagement.Models.Warehouse", "Warehouse")
                        .WithMany("Stocks")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("StockManagement.Models.StockTransfer", b =>
                {
                    b.HasOne("StockManagement.Models.Stock", "FromStock")
                        .WithMany("FromStockTransfers")
                        .HasForeignKey("FromStockID");

                    b.HasOne("StockManagement.Models.Product", "Product")
                        .WithMany("StockTransfers")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockManagement.Models.Stock", "ToStock")
                        .WithMany("ToStockTransfers")
                        .HasForeignKey("ToStockID");

                    b.Navigation("FromStock");

                    b.Navigation("Product");

                    b.Navigation("ToStock");
                });

            modelBuilder.Entity("StockManagement.Models.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("StockManagement.Models.Product", b =>
                {
                    b.Navigation("Stocks");

                    b.Navigation("StockTransfers");
                });

            modelBuilder.Entity("StockManagement.Models.Stock", b =>
                {
                    b.Navigation("FromStockTransfers");

                    b.Navigation("ToStockTransfers");
                });

            modelBuilder.Entity("StockManagement.Models.Warehouse", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
