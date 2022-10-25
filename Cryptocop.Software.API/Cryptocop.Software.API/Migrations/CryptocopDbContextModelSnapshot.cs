﻿// <auto-generated />
using System;
using Cryptocop.Software.API.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cryptocop.Software.API.Migrations
{
    [DbContext(typeof(CryptocopDbContext))]
    partial class CryptocopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardHolderName")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("text");

                    b.Property<string>("MaskedCreditCard")
                        .HasColumnType("text");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductIdentifier")
                        .HasColumnType("text");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.PaymentCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardHolderName")
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .HasColumnType("text");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PaymentCard");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductIdentifier")
                        .HasColumnType("text");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("integer");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItem");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.Address", b =>
                {
                    b.HasOne("Cryptocop.Software.API.Repositories.Entities.User", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.Order", b =>
                {
                    b.HasOne("Cryptocop.Software.API.Repositories.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.OrderItem", b =>
                {
                    b.HasOne("Cryptocop.Software.API.Repositories.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.PaymentCard", b =>
                {
                    b.HasOne("Cryptocop.Software.API.Repositories.Entities.User", null)
                        .WithMany("PaymentCards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.ShoppingCart", b =>
                {
                    b.HasOne("Cryptocop.Software.API.Repositories.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("Cryptocop.Software.API.Repositories.Entities.ShoppingCart", null)
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Cryptocop.Software.API.Repositories.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");

                    b.Navigation("PaymentCards");
                });
#pragma warning restore 612, 618
        }
    }
}
