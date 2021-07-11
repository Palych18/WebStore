using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureLogging((host, log) => log
                //    .ClearProviders()
                //    .AddDebug()
                //    //.AddConsole(opt => opt.IncludeScopes = true)
                //    .AddEventLog()
                //    .AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Information)
                //    .AddFilter<ConsoleLoggerProvider>("Microsoft", Level => Level >= LogLevel.Information))
                .ConfigureWebHostDefaults(host => host
                   .UseStartup<Startup>()
                )
            ;
    }
}
