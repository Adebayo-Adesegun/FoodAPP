using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp_Customer.Helpers;
using FoodApp_Customer.Interface;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Options;

namespace FoodApp_Customer.Models
{
    public class BusConfigurator : IBusConfigurator
    {
        private readonly RabbitMqSettings _rabbitSettings;
        public BusConfigurator(IOptionsSnapshot<RabbitMqSettings> options)
        {
            _rabbitSettings = options.Value;
        }

        public IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            try
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(_rabbitSettings.ServerUrl), hst =>
                    {
                        hst.Username(_rabbitSettings.Username);
                        hst.Password(_rabbitSettings.Password);
                    });
                    registrationAction?.Invoke(cfg, host);
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
