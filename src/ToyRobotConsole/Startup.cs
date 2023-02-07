using Frontier.CodeChallange.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotConsole
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            // no configuration required, Maybe later
            //var environmentName =
            //    Environment.GetEnvironmentVariable("CORE_ENVIRONMENT");

            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            services.AddApplication();
            services.AddScoped<App>();

            return services;

        }
    }
}
