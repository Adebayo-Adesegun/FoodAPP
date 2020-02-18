using System;
using System.Threading.Tasks;
using FoodApp_OrderProcessing.Contracts;
using MassTransit;

namespace FoodApp_OrderProcessing.Models
{
    public class ReceiveOrderConsumerService: IConsumer<ICustomerOrderProcess>
    {
        public async Task Consume(ConsumeContext<ICustomerOrderProcess> context)
        {
            await Console.Out.WriteLineAsync($"Updating CustomerOrderProcess: {context.Message.CustomerId}");
            // Log the CustomerOrder that was received
        }

    }
}
