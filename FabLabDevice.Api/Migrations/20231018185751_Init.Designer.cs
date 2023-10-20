﻿// <auto-generated />
using System;
using FabLabDevice.Api.Domains.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FabLabDevice.Api.Migrations
{
    [DbContext(typeof(FabLabDbContext))]
    [Migration("20231018185751_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Borrow", b =>
                {
                    b.Property<Guid>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Borrower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnSite")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BorrowId");

                    b.HasIndex("ProjectName");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Borrow_Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BorrowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EquipmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BorrowId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("BorrowsEquipments");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Equipment", b =>
                {
                    b.Property<string>("EquipmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeOfManage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipmentTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("YearOfSupply")
                        .HasColumnType("datetime2");

                    b.HasKey("EquipmentId");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("SupplierName");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.EquipmentType", b =>
                {
                    b.Property<string>("EquipmentTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentTypeId");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Project", b =>
                {
                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectName");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierName");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Borrow", b =>
                {
                    b.HasOne("FabLabDevice.Api.Domains.Models.Project", "Project")
                        .WithMany("Borrows")
                        .HasForeignKey("ProjectName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Borrow_Equipment", b =>
                {
                    b.HasOne("FabLabDevice.Api.Domains.Models.Borrow", "Borrow")
                        .WithMany("BorrowEquipments")
                        .HasForeignKey("BorrowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FabLabDevice.Api.Domains.Models.Equipment", "Equipment")
                        .WithMany("BorrowEquipments")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Borrow");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Equipment", b =>
                {
                    b.HasOne("FabLabDevice.Api.Domains.Models.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FabLabDevice.Api.Domains.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Location", b =>
                {
                    b.HasOne("FabLabDevice.Api.Domains.Models.Equipment", null)
                        .WithOne("Location")
                        .HasForeignKey("FabLabDevice.Api.Domains.Models.Location", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Borrow", b =>
                {
                    b.Navigation("BorrowEquipments");
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Equipment", b =>
                {
                    b.Navigation("BorrowEquipments");

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("FabLabDevice.Api.Domains.Models.Project", b =>
                {
                    b.Navigation("Borrows");
                });
#pragma warning restore 612, 618
        }
    }
}
