using System;
using FoodApp_Customer.Data;
using FoodApp_Customer.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodApp_Customer.Models
{
    public class RepoService : IRepository
    {
        private readonly FoodDbContext _context;
        public RepoService(FoodDbContext context)
        {
            _context = context;
        }
        public int CreateCustomer(Customer customer)
        {
            _context.Customers.AddRange(customer);
            _context.SaveChanges();
            return customer.Id;
        }
    }
}
