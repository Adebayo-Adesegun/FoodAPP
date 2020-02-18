using System.Threading.Tasks;
using FoodApp_Customer.Models;

namespace FoodApp_Customer.Interface
{
    public interface IMessages
    {
        Task<bool> QueeueMessage(CustomerOrder order, string exchangeTopicName);
    }
}
