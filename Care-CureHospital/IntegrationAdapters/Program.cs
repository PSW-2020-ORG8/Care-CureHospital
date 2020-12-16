using System;
using System.Threading.Tasks;
using IntegrationAdapters.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IntegrationAdapters
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine(":");
            PrintMenu();
            string input = Console.ReadLine();
            if (ValidInput(input))
            {
                await HttpInquiriesController.SendRequest(int.Parse(input));
            }
            else
            {
                Console.WriteLine("Input not valid!");
            }
            CreateHostBuilder(args).Build().Run();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1 - Send request to get medicaments");
        }

        private static bool ValidInput(string input)
        {
            int n;
            bool isNumeric = int.TryParse(input, out n);
            if (isNumeric)
            {
                return n >= 1 && n <= 4;
            }
            else
            {
                return false;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
