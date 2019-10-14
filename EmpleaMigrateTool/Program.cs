using System;
using System.Threading.Tasks;
using AutoMapper;
using EmpleaMigrateTool.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmpleaMigrateTool
{

    public class Program
    {
        public static async Task Main()
        {
            IServiceCollection services = new ServiceCollection();
           
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>();

            var loggerp = 
                logger
                    .AddConsole(LogLevel.Debug)
                    .CreateLogger<Program>(); 

            
            loggerp.LogDebug("Logger is working!");
            
            // Get Service and call method
            var service = serviceProvider.GetService<IMyService>();
            await service.MyServiceMethod();
        }
    }
    }

