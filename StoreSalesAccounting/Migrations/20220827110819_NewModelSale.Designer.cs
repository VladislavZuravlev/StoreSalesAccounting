﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreSalesAccounting.Models;

#nullable disable

namespace StoreSalesAccounting.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220827110819_NewModelSale")]
    partial class NewModelSale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StoreSalesAccounting.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cash")
                        .HasColumnType("int");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NonCash")
                        .HasColumnType("int");

                    b.Property<int>("OnlineCash")
                        .HasColumnType("int");

                    b.Property<int>("TotalRevenue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("StoreSalesAccounting.Models.Repair", b =>
                {
                    b.Property<int>("RepairId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepairId"), 1L, 1);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GiveAway")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuitarCase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Master")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusicalInstrument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceivingEmployee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RepairEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RepairStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TechnicalTask")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RepairId");

                    b.HasIndex("ClientNumber")
                        .IsUnique();

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("StoreSalesAccounting.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SaleAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("StoreSalesAccounting.Models.StoreRevenue", b =>
                {
                    b.Property<int>("StoreRevenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreRevenueId"), 1L, 1);

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreCash")
                        .HasColumnType("int");

                    b.Property<int>("StoreNonCash")
                        .HasColumnType("int");

                    b.Property<int>("StoreOnlineCash")
                        .HasColumnType("int");

                    b.Property<int>("StoreTotalRevenue")
                        .HasColumnType("int");

                    b.HasKey("StoreRevenueId");

                    b.ToTable("StoreRevenues");
                });

            modelBuilder.Entity("StoreSalesAccounting.Models.Sale", b =>
                {
                    b.HasOne("StoreSalesAccounting.Models.Employee", "Employee")
                        .WithMany("Sales")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StoreSalesAccounting.Models.Employee", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}