﻿// <auto-generated />
using System;
using HHPWServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HHPWServer.Migrations
{
    [DbContext(typeof(HhpwDbContext))]
    partial class HhpwDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HHPWServer.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemName = "Cheese Pizza",
                            ItemPrice = 18.00m
                        },
                        new
                        {
                            Id = 2,
                            ItemName = "Pepeproni Pizza",
                            ItemPrice = 20.00m
                        },
                        new
                        {
                            Id = 3,
                            ItemName = "Buffalo Style Wings",
                            ItemPrice = 15.00m
                        },
                        new
                        {
                            Id = 4,
                            ItemName = "Garlic Knots",
                            ItemPrice = 10.00m
                        });
                });

            modelBuilder.Entity("HHPWServer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ClosedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OrderOpen")
                        .HasColumnType("boolean");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("OrderType")
                        .HasColumnType("text");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("TipAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "le@gmail.com",
                            Name = "Laura Epling",
                            OrderOpen = true,
                            OrderTotal = 0m,
                            PhoneNumber = "615-555-5555",
                            TipAmount = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "mm@gmail.com",
                            Name = "Micaela Miller",
                            OrderOpen = true,
                            OrderTotal = 0m,
                            PhoneNumber = "615-555-5555",
                            TipAmount = 0
                        },
                        new
                        {
                            Id = 3,
                            Email = "nl@gmail.com",
                            Name = "Nik Lizcano",
                            OrderOpen = false,
                            OrderTotal = 0m,
                            PhoneNumber = "615-555-5555",
                            TipAmount = 0
                        },
                        new
                        {
                            Id = 4,
                            Email = "jp@gmail.com",
                            Name = "Jason Peterson",
                            OrderOpen = true,
                            OrderTotal = 0m,
                            PhoneNumber = "615-555-5555",
                            TipAmount = 0
                        });
                });

            modelBuilder.Entity("HHPWServer.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            OrderId = 1
                        },
                        new
                        {
                            Id = 3,
                            ItemId = 3,
                            OrderId = 2
                        });
                });

            modelBuilder.Entity("HHPWServer.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "In-Person"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("HHPWServer.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cash"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Check"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Debit"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Credit"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mobile-Pay"
                        });
                });

            modelBuilder.Entity("HHPWServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Maggie"
                        });
                });

            modelBuilder.Entity("HHPWServer.Models.OrderItem", b =>
                {
                    b.HasOne("HHPWServer.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HHPWServer.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
