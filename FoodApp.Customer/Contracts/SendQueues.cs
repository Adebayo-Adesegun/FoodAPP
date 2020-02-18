using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp_Customer.Helpers;
using FoodApp_Customer.Models;
using MassTransit;
using Microsoft.Extensions.Options;

namespace FoodApp_Customer.Contracts
{
    public static class SendQueues
    {
        /// <summary>
        /// Send Directly to an endpoint
        /// </summary>
        /// <param name="sendEndpointProvider"></param>
        /// <param name="customerOrder"></param>
        /// <returns></returns>
        public static async Task SendOrder(ISendEndpointProvider sendEndpointProvider, CustomerOrderProcess customerOrder)
        {
            var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("localhost//order_submit_queue"));
            await endpoint.Send(customerOrder);
        }

        /// <summary>
        /// Publish the Order mEssage
        /// </summary>
        /// <param name="publishEndpoint"></param>
        /// <param name="customerOrder"></param>
        /// <returns></returns>
        public static async Task NotifyOrderSubmitted(IPublishEndpoint publishEndpoint, CustomerOrderProcess customerOrder)
        {
            await publishEndpoint.Publish<CustomerOrderProcess>(customerOrder);
        }
    }
}
