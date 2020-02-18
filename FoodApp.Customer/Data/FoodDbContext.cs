using FoodApp_Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp_Customer.Data
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) { }

        public DbSet<Customer> Customers {get;set;}
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
    }
}
