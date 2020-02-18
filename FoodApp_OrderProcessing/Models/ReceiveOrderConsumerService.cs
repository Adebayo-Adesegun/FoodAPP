using System;
using System.Threading.Tasks;
using MassTransit;
using SharedLibrary.Contracts;

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
