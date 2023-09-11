﻿// <auto-generated />
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoDbContexts))]
    [Migration("20230909054919_CreateCityInfoDataBase")]
    partial class CreateCityInfoDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This Is Tehran",
                            Name = "Tehran"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This Is Mashhad",
                            Name = "Mashhad"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This Is Shahroud",
                            Name = "Shahroud"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This Is Esfehan",
                            Name = "Esfehan"
                        },
                        new
                        {
                            Id = 5,
                            Description = "This Is Tanriz",
                            Name = "Tanriz"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfIntrest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("cityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("cityId");

                    b.ToTable("PointsOfIntrest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This Is Point Of Intrest 1",
                            Name = "Point Of Intrest 1",
                            cityId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "This Is Point Of Intrest 2",
                            Name = "Point Of Intrest 2",
                            cityId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "This Is Point Of Intrest 3",
                            Name = "Point Of Intrest 3",
                            cityId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "This Is Point Of Intrest 4",
                            Name = "Point Of Intrest 4",
                            cityId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "This Is Point Of Intrest 5",
                            Name = "Point Of Intrest 5",
                            cityId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "This Is Point Of Intrest 6",
                            Name = "Point Of Intrest 6",
                            cityId = 3
                        },
                        new
                        {
                            Id = 7,
                            Description = "This Is Point Of Intrest 7",
                            Name = "Point Of Intrest 7",
                            cityId = 4
                        },
                        new
                        {
                            Id = 8,
                            Description = "This Is Point Of Intrest 8",
                            Name = "Point Of Intrest 8",
                            cityId = 4
                        },
                        new
                        {
                            Id = 9,
                            Description = "This Is Point Of Intrest 9",
                            Name = "Point Of Intrest 9",
                            cityId = 5
                        },
                        new
                        {
                            Id = 10,
                            Description = "This Is Point Of Intrest 10",
                            Name = "Point Of Intrest 10",
                            cityId = 5
                        });
                });

            modelBuilder.Entity("CityInfo.API.Entities.PointOfIntrest", b =>
                {
                    b.HasOne("CityInfo.API.Entities.City", "City")
                        .WithMany("PointOfIntrest")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Entities.City", b =>
                {
                    b.Navigation("PointOfIntrest");
                });
#pragma warning restore 612, 618
        }
    }
}