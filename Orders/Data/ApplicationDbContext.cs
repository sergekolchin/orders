using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var random = new Random();
            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, Number = "1", Date = DateTime.UtcNow.AddHours(-random.Next(24 * 30)), Status = OrderStatus.InProgress });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 2, Number = "2", Date = DateTime.UtcNow.AddHours(-random.Next(24 * 30)), Status = OrderStatus.Complete });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 3, Number = "3", Date = DateTime.UtcNow.AddHours(-random.Next(24 * 30)), Status = OrderStatus.Complete });

            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Apple", Price = GetRandomPrice(random)},
                new Product {Id = 2, Name = "Banana", Price = GetRandomPrice(random)},
                new Product {Id = 3, Name = "Mango", Price = GetRandomPrice(random)},
                new Product {Id = 4, Name = "Pineapple", Price = GetRandomPrice(random)},
                new Product {Id = 5, Name = "Orange", Price = GetRandomPrice(random)}
            };

            foreach (var product in products)
            {
                modelBuilder.Entity<Product>().HasData(product);
            }

            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 1, OrderId = 1, ProductId = 1, Quantity = random.Next(1, 10), Price = products[0].Price });
            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 2, OrderId = 1, ProductId = 3, Quantity = random.Next(1, 10), Price = products[2].Price });
            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 3, OrderId = 1, ProductId = 5, Quantity = random.Next(1, 10), Price = products[4].Price });
            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 4, OrderId = 1, ProductId = 4, Quantity = random.Next(1, 10), Price = products[3].Price });

            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 5, OrderId = 2, ProductId = 2, Quantity = random.Next(1, 10), Price = products[1].Price });
            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 6, OrderId = 2, ProductId = 5, Quantity = random.Next(1, 10), Price = products[4].Price });

            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 7, OrderId = 3, ProductId = 1, Quantity = random.Next(1, 10), Price = products[0].Price });
            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 8, OrderId = 3, ProductId = 2, Quantity = random.Next(1, 10), Price = products[1].Price });
            modelBuilder.Entity<OrderLine>().HasData(new OrderLine { Id = 9, OrderId = 3, ProductId = 3, Quantity = random.Next(1, 10), Price = products[2].Price });
        }

        private static decimal GetRandomPrice(Random random)
        {
            return random.Next(1, 5) + (decimal)Math.Round(random.NextDouble(), 2);
        }
    }
}
