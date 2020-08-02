using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Web.Services;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IEventDispatcher, EventDispatcher>();
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<MessageConsumer>()
                        .Endpoint(e =>
                        {
                            e.Name = "log-events-listener";
                        });
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            // RabbitMQ Host & Credentials
                            cfg.Host("localhost", "/", h =>
                            {
                                h.Username("guest");
                                h.Password("guest");
                            });
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddHostedService<AmpqListenerService>();
                });
    }
}
