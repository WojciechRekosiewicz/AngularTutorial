using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using MovieShop.Data;

namespace MovieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            RunSeeding(host);

            host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<FilmSeeder>();
                seeder.SeedAsync().Wait();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {

            //Remove conf options . Prevent legacy code
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
            
        }
    }
}


//public class Program
//{
//    public static void Main(string[] args)
//    {

//        CreateWebHostBuilder(args).Build().Run();
//    }

//    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//        WebHost.CreateDefaultBuilder(args)
//            .ConfigureAppConfiguration(SetupConfiguration)
//            .UseStartup<Startup>();

//    private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
//    {

//        //Remove conf options . Prevent legacy code
//        builder.Sources.Clear();

//        builder.AddJsonFile("config.json", false, true)
//            .AddEnvironmentVariables();

//    }
//}