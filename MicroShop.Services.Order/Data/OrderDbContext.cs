using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Services.Order.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Services.Order.Data
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        {
            
        }
        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<Entities.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Order>().ToTable("Order");
            modelBuilder.Entity<Entities.Order>().HasMany(x => x.Items);
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
        }
    }
}
