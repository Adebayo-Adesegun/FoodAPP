using FoodApp_Customer.Data;
using FoodApp_Customer.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using GreenPipes;
using FoodApp_Customer.Interface;
using FoodApp_Customer.Models;

namespace FoodApp_Customer
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
            services.AddHealthChecks();

            services.AddDbContext<FoodDbContext>((options) => options.UseSqlServer(Configuration.GetConnectionString("FoodAppConnection")));

            services.Configure<RabbitMqSettings>(Configuration.GetSection("RabbitMqSettings"));

            services.AddControllers();

            services.AddScoped<IRepository, RepoService>();

            services.AddScoped<IBusConfigurator, BusConfigurator>();
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready") });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
