using System;
using FoodApp_OrderProcessing.Models;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodApp_OrderProcessing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Consumer dependencies should be scoped
            //services.AddScoped<ReceiveOrderConsumerService>();
            //var buscontrol = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    cfg.Host("localhost");

            //    cfg.ReceiveEndpoint("customerorderprocess", e =>
            //    {
            //        e.Consumer<ReceiveOrderConsumerService>();
            //    });
            //});
            //buscontrol.Start();

            //services.AddMassTransit(c =>
            //{
            //    c.AddConsumer<ReceiveOrderConsumerService>();
            //});

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "CustomerOrderProcess", ep =>
                {
                    ep.Consumer(() => new ReceiveOrderConsumerService());
                });
            });

            bus.Start();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
