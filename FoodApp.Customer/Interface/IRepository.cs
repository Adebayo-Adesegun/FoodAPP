using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp_Customer.Models;

namespace FoodApp_Customer.Interface
{
    public interface IRepository
    {
        int CreateCustomer(Customer customer);
    }
}
