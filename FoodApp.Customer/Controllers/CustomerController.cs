using System;
using System.Threading.Tasks;
using FoodApp_Customer.Helpers;
using FoodApp_Customer.Interface;
using FoodApp_Customer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using SharedLibrary.Contracts;

namespace FoodApp_Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IBusConfigurator _busConfig;
        private readonly RabbitMqSettings _rabbit;
        public CustomerController(IRepository repo, IBusConfigurator busConfig, IOptionsSnapshot<RabbitMqSettings> options)
        {
            _repo = repo;
            _busConfig = busConfig;
            _rabbit = options.Value;
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer model)
        {
            int customerId = _repo.CreateCustomer(model);
            return Ok(customerId);
        }

        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> CreateOrder(ICustomerOrderProcess model)
        {
            // Customer order is sent to an order processing microservice queue an exchange name.
            try
            {
                var bus = _busConfig.ConfigureBus();
                await bus.StartAsync();
                var sendToUri = new Uri($"{_rabbit.ServerUrl}{_rabbit.ExchangeTopicName}");
                var endPoint = await bus.GetSendEndpoint(sendToUri);
                await endPoint.Send(model);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}