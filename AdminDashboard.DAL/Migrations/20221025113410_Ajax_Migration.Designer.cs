﻿// <auto-generated />
using System;
using AdminDashboard.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdminDashboard.DAL.Migrations
{
    [DbContext(typeof(AdminDashboardContext))]
    [Migration("20221025113410_Ajax_Migration")]
    partial class Ajax_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("AdminDashboard.DAL.Entity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.City", b =>
                {
                    b.HasOne("AdminDashboard.DAL.Entity.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.District", b =>
                {
                    b.HasOne("AdminDashboard.DAL.Entity.City", "City")
                        .WithMany("District")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.Employee", b =>
                {
                    b.HasOne("AdminDashboard.DAL.Entity.Departments", "Departments")
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminDashboard.DAL.Entity.District", "District")
                        .WithMany("Employee")
                        .HasForeignKey("DistrictId");

                    b.Navigation("Departments");

                    b.Navigation("District");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.City", b =>
                {
                    b.Navigation("District");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.Country", b =>
                {
                    b.Navigation("City");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.Departments", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AdminDashboard.DAL.Entity.District", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
