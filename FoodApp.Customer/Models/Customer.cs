using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp_Customer.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;
        public List<CustomerOrder> CustomerOrders { get; set; }
    }
}
