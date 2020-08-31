using MicroShop.Services.Customer.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Services.Customer.Data
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext>options):base(options)
        {
            
        }


        public DbSet<Entities.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entities.Customer>().ToTable("Customer");
        }
    }
}
