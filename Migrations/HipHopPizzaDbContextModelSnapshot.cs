﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HipHopPizza.Migrations
{
    [DbContext(typeof(HipHopPizzaDbContext))]
    partial class HipHopPizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HipHopPizza.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://s3-media0.fl.yelpcdn.com/bphoto/OQpAaFjU-KVpCpljCoHfVQ/o.jpg",
                            Name = "Cheeseburger Pizza",
                            Price = 14m
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://cdn.cdkitchen.com/recipes/images/2010/07/11102-1568-mx.jpg",
                            Name = "Cold Veggie Pizza",
                            Price = 10m
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSN37d5qV3N4tAsDsCuihjbnWjV1xNccQy0h2TjR9C_Q&s",
                            Name = "Pepperoni Lovers Pizza",
                            Price = 12m
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://fatapplesrestaurant.com/cdn/shop/products/five-cheese_800x.jpg?v=1612571720",
                            Name = "Cheese Pizza",
                            Price = 10m
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2019/01/Baked-Buffalo-Wings_0.jpg",
                            Name = "The Meat Sweats Wings",
                            Price = 22m
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "https://www.smoking-meat.com/image-files/honey-barbecue-smoked-wings-575x384-1-500x375.jpg",
                            Name = "Honey BBQ Wings",
                            Price = 17m
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "https://alldayidreamaboutfood.com/wp-content/uploads/2022/10/Crispy-Cajun-Wings.jpg",
                            Name = "Crispy Cajun Wings",
                            Price = 15m
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSabgmlhTm0aFVa9CKI41cLw-EGA_A87x7jY-4gqkeTlA&s",
                            Name = "Sweet and Spicy Wings",
                            Price = 20m
                        });
                });

            modelBuilder.Entity("HipHopPizza.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .HasColumnType("text");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("text");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Tip")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerEmail = "johnnyyourmomcalled@johnnybusiness.net",
                            CustomerName = "Johnny Saniat",
                            CustomerPhone = "615-555-5512",
                            IsComplete = true,
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderTypeId = 1,
                            Tip = 10m
                        },
                        new
                        {
                            Id = 2,
                            CustomerEmail = "keanabusiness@gmail.com",
                            CustomerName = "Keana Cobarde",
                            CustomerPhone = "615-555-1255",
                            IsComplete = true,
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderTypeId = 2,
                            Tip = 5m
                        },
                        new
                        {
                            Id = 3,
                            CustomerEmail = "uevadrankbaileys4rmashu@yahoo.com",
                            CustomerName = "Greg Markus",
                            CustomerPhone = "615-555-2782",
                            IsComplete = false,
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderTypeId = 1,
                            Tip = 8m
                        },
                        new
                        {
                            Id = 4,
                            CustomerEmail = "number1grump@outlook.com",
                            CustomerName = "Ryan Shore",
                            CustomerPhone = "615-555-7893",
                            IsComplete = false,
                            OrderDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderTypeId = 2,
                            Tip = 2m
                        });
                });

            modelBuilder.Entity("HipHopPizza.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("HipHopPizza.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Walk-In"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Call-In"
                        });
                });

            modelBuilder.Entity("HipHopPizza.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HipHopPizza.Models.OrderItem", b =>
                {
                    b.HasOne("HipHopPizza.Models.Item", "Item")
                        .WithMany("Orders")
                        .HasForeignKey("ItemId");

                    b.HasOne("HipHopPizza.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HipHopPizza.Models.Item", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("HipHopPizza.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
