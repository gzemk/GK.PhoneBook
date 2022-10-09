﻿// <auto-generated />
using System;
using GK.PhoneBook.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GK.PhoneBook.Infrastructure.Migrations
{
    [DbContext(typeof(PhoneBookDbContext))]
    partial class PhoneBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GK.PhoneBook.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies", "pb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2734),
                            EmployeeCount = 50,
                            Name = "Blue Company",
                            UpdatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2748)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2751),
                            EmployeeCount = 30,
                            Name = "Green Company",
                            UpdatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2752)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2753),
                            EmployeeCount = 10,
                            Name = "Red Company",
                            UpdatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2753)
                        });
                });

            modelBuilder.Entity("GK.PhoneBook.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Persons", "pb");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Izmir/Turkey",
                            CompanyId = 1,
                            CreatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2844),
                            FullName = "Gizem Kgizem",
                            PhoneNumber = "+905073452312",
                            UpdatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2845)
                        },
                        new
                        {
                            Id = 2,
                            Address = "Ankara/Turkey",
                            CompanyId = 2,
                            CreatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2846),
                            FullName = "Rose KRose",
                            PhoneNumber = "+905073455512",
                            UpdatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2846)
                        },
                        new
                        {
                            Id = 3,
                            Address = "Istanbul/Turkey",
                            CompanyId = 3,
                            CreatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2848),
                            FullName = "Melinda GMelindaGates",
                            PhoneNumber = "+905073455512",
                            UpdatedDate = new DateTime(2022, 10, 9, 22, 36, 22, 375, DateTimeKind.Local).AddTicks(2848)
                        });
                });

            modelBuilder.Entity("GK.PhoneBook.Domain.Entities.Person", b =>
                {
                    b.HasOne("GK.PhoneBook.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}