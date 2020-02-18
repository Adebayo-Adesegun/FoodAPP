using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace FoodApp_Customer.Interface
{
    public interface IBusConfigurator
    {
        IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null);
    }
}
