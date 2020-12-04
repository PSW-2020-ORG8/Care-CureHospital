using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAdapters.RabbitMQ;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntegrationAdapters
{
    public class Program
    {
        public static object Messages { get; internal set; }
        public static List<Message> ListOfMessages = new List<Message>();
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            CreateHostBuilderMessages(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHostBuilder CreateHostBuilderMessages(string[] args) =>
            Host.CreateDefaultBuilder(args).UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<TimerService>();
                    services.AddHostedService<RabbitMQService>();
                });
    }
}
