﻿// <auto-generated />
using System;
using ExoticAuctionHouse_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExoticAuctionHouse_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231119095532_FollowingCars")]
    partial class FollowingCars
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthModels.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attributes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attributes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("301f3cf0-83c3-46e6-a801-19e98846c39e"),
                            Category = "Audio and multimedia",
                            Value = "Apple CarPlay"
                        },
                        new
                        {
                            Id = new Guid("c110d251-5300-4225-9f45-6171a620dfad"),
                            Category = "Audio and multimedia",
                            Value = "Android Auto"
                        },
                        new
                        {
                            Id = new Guid("544dad6f-4a43-433f-839d-a1c081d3a280"),
                            Category = "Audio and multimedia",
                            Value = "Interface Bluetooth"
                        },
                        new
                        {
                            Id = new Guid("2f1505eb-d977-405a-b604-6da418bfa99b"),
                            Category = "Audio and multimedia",
                            Value = "Radio"
                        },
                        new
                        {
                            Id = new Guid("2dbc7600-a69f-44e3-940e-af055125bad9"),
                            Category = "Audio and multimedia",
                            Value = "USB socket"
                        },
                        new
                        {
                            Id = new Guid("2601ecf3-ee8a-493f-8836-5b7a2b05abbd"),
                            Category = "Audio and multimedia",
                            Value = "HIFI speaker"
                        },
                        new
                        {
                            Id = new Guid("bb1bd376-e2e5-4c4f-a37d-8095a9ecb0c5"),
                            Category = "Audio and multimedia",
                            Value = "Touchscreen"
                        },
                        new
                        {
                            Id = new Guid("af079b05-e76a-4eb8-a80c-0ee83efb76fb"),
                            Category = "Comfort and accessories",
                            Value = "Automatic air conditioning"
                        },
                        new
                        {
                            Id = new Guid("47419622-f81c-4cde-8fc1-c15a9195d9a1"),
                            Category = "Comfort and accessories",
                            Value = "Leather seats"
                        },
                        new
                        {
                            Id = new Guid("a2d48c9a-094e-466e-a00c-f99b6fa585ce"),
                            Category = "Comfort and accessories",
                            Value = "Heated seats"
                        },
                        new
                        {
                            Id = new Guid("912267ca-7c5c-4183-87a4-b52cbf1839ed"),
                            Category = "Comfort and accessories",
                            Value = "Leather steering wheel"
                        },
                        new
                        {
                            Id = new Guid("f13b2c30-6d9b-46c0-9992-457c62aebef7"),
                            Category = "Comfort and accessories",
                            Value = "Multifunction steering wheel"
                        },
                        new
                        {
                            Id = new Guid("3a9c49bb-8271-442c-9dba-84804fcae7ce"),
                            Category = "Comfort and accessories",
                            Value = "Electrict windows"
                        },
                        new
                        {
                            Id = new Guid("f4ba1bae-2a41-4b0d-a9d6-b7be49e92d5a"),
                            Category = "Driver assistance system",
                            Value = "Headlights with LED technology"
                        },
                        new
                        {
                            Id = new Guid("6defde8a-a93a-4ebf-89fd-b1fc7f77c055"),
                            Category = "Driver assistance system",
                            Value = "Park assistant"
                        },
                        new
                        {
                            Id = new Guid("4703efb5-023b-4283-80e4-d7ec250265c6"),
                            Category = "Driver assistance system",
                            Value = "Heated side mirror"
                        },
                        new
                        {
                            Id = new Guid("0ffe3e6a-94ea-4218-9682-efb5fd2ad134"),
                            Category = "Driver assistance system",
                            Value = "ESP"
                        },
                        new
                        {
                            Id = new Guid("8aeba385-2812-4c88-9bc5-9e2e30f1364c"),
                            Category = "Driver assistance system",
                            Value = "Daytime running lights"
                        },
                        new
                        {
                            Id = new Guid("c02b611f-aa53-4ade-8cf9-27629ae13f18"),
                            Category = "Driver assistance system",
                            Value = "Fog lamps"
                        },
                        new
                        {
                            Id = new Guid("b96d92ed-03db-4781-ac6c-827e228e8823"),
                            Category = "Driver assistance system",
                            Value = "System start/stop"
                        },
                        new
                        {
                            Id = new Guid("eec1befa-ae73-448b-94c5-af489e5e8e0b"),
                            Category = "Driver assistance system",
                            Value = "Power steering"
                        },
                        new
                        {
                            Id = new Guid("2101e8db-5a7a-450f-94a6-991eb8e4087f"),
                            Category = "Security",
                            Value = "ABS"
                        },
                        new
                        {
                            Id = new Guid("827a0994-a4fc-4cac-b330-f7a380c36c91"),
                            Category = "Security",
                            Value = "ESP"
                        },
                        new
                        {
                            Id = new Guid("b021441b-bb48-44d5-9e6e-0cbfa41393db"),
                            Category = "Security",
                            Value = "Isofix"
                        });
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.Auction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmountStarting")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("BiddingBegins")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("IsEnd")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.AuctionHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("SoldAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("AuctionHistory");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BodyType")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("Generation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Horsepower")
                        .HasColumnType("int");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("MainImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.CarAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("CarId");

                    b.ToTable("CarAttributes");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.FollowedCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FollowedCars");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.Auction", b =>
                {
                    b.HasOne("ExoticAuctionHouseModel.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.AuctionHistory", b =>
                {
                    b.HasOne("ExoticAuctionHouseModel.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("ExoticAuctionHouseModel.Models.CarAttribute", b =>
                {
                    b.HasOne("ExoticAuctionHouseModel.Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExoticAuctionHouseModel.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
