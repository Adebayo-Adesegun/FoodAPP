using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp_OrderProcessing.Contracts
{
    public interface ICustomerOrderProcess
    {
        public string OrderDate { get; set; }
        public string Item { get; set; }
        public int CustomerId { get; set; }
    }
}
