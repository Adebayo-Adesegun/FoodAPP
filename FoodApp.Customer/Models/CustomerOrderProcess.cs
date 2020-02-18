using System;

namespace FoodApp_Customer.Models
{
    [Serializable]
    public class CustomerOrderProcess
    {
        public string OrderDate { get; set; }
        public string Item { get; set; }
        public int CustomerId { get; set; }
    }
}
