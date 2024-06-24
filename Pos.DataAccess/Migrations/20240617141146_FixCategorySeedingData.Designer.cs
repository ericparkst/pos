﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pos.DataAccess.Data;

#nullable disable

namespace Pos.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240617141146_FixCategorySeedingData")]
    partial class FixCategorySeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pos_backend.Models.Category", b =>
                {
                    b.Property<string>("CategoryCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NameEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryCode");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryCode = "201",
                            DeptCode = "1",
                            Id = 1,
                            NameEN = "Eggplant",
                            NameKO = "가지류"
                        },
                        new
                        {
                            CategoryCode = "202",
                            DeptCode = "1",
                            Id = 2,
                            NameEN = "Potato",
                            NameKO = "감자류"
                        },
                        new
                        {
                            CategoryCode = "203",
                            DeptCode = "1",
                            Id = 3,
                            NameEN = "Sweet Potato",
                            NameKO = "고구마류"
                        });
                });

            modelBuilder.Entity("Pos_backend.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameKO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeptCode = "1",
                            NameEN = "Produce",
                            NameKO = "청과"
                        },
                        new
                        {
                            Id = 2,
                            DeptCode = "2",
                            NameEN = "Fish",
                            NameKO = "수산"
                        },
                        new
                        {
                            Id = 3,
                            DeptCode = "3",
                            NameEN = "Meat",
                            NameKO = "정육"
                        },
                        new
                        {
                            Id = 4,
                            DeptCode = "4",
                            NameEN = "Deli",
                            NameKO = "델리"
                        },
                        new
                        {
                            Id = 5,
                            DeptCode = "5",
                            NameEN = "Houseware",
                            NameKO = "하우스웨어"
                        },
                        new
                        {
                            Id = 6,
                            DeptCode = "6",
                            NameEN = "Grocery",
                            NameKO = "그로서리"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}