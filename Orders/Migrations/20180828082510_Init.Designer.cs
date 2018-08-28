﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders.Data;

namespace Orders.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180828082510_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orders.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, Date = new DateTime(2018, 8, 25, 19, 25, 10, 187, DateTimeKind.Utc), Number = "1", Status = 0 },
                        new { Id = 2, Date = new DateTime(2018, 8, 24, 11, 25, 10, 187, DateTimeKind.Utc), Number = "2", Status = 1 },
                        new { Id = 3, Date = new DateTime(2018, 8, 17, 14, 25, 10, 187, DateTimeKind.Utc), Number = "3", Status = 1 }
                    );
                });

            modelBuilder.Entity("Orders.Models.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");

                    b.HasData(
                        new { Id = 1, OrderId = 1, Price = 4.73m, ProductId = 1, Quantity = 9 },
                        new { Id = 2, OrderId = 1, Price = 3.17m, ProductId = 3, Quantity = 6 },
                        new { Id = 3, OrderId = 1, Price = 2.15m, ProductId = 5, Quantity = 2 },
                        new { Id = 4, OrderId = 1, Price = 3.24m, ProductId = 4, Quantity = 2 },
                        new { Id = 5, OrderId = 2, Price = 4.66m, ProductId = 2, Quantity = 2 },
                        new { Id = 6, OrderId = 2, Price = 2.15m, ProductId = 5, Quantity = 2 },
                        new { Id = 7, OrderId = 3, Price = 4.73m, ProductId = 1, Quantity = 8 },
                        new { Id = 8, OrderId = 3, Price = 4.66m, ProductId = 2, Quantity = 9 },
                        new { Id = 9, OrderId = 3, Price = 3.17m, ProductId = 3, Quantity = 2 }
                    );
                });

            modelBuilder.Entity("Orders.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Name = "Apple", Price = 4.73m },
                        new { Id = 2, Name = "Banana", Price = 4.66m },
                        new { Id = 3, Name = "Mango", Price = 3.17m },
                        new { Id = 4, Name = "Pineapple", Price = 3.24m },
                        new { Id = 5, Name = "Orange", Price = 2.15m }
                    );
                });

            modelBuilder.Entity("Orders.Models.OrderLine", b =>
                {
                    b.HasOne("Orders.Models.Order", "Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orders.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
