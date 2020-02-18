using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp_Customer.Models
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Item { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
