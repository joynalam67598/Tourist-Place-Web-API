using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using TouristPlaceWebAPI;

namespace TouristPlaceWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webhost =>
            {
                webhost.UseStartup<Startup>();
            });

        }
    }
}