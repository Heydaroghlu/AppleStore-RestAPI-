using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apple.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           // Add this line:
           .WriteTo.File(
              System.IO.Path.Combine("D:\\Projects\\Apple", "LogFiles", "ApplicationApple", "diagnostics.txt"),
              rollingInterval: RollingInterval.Day,
              fileSizeLimitBytes: 10 * 1024 * 1024,
              retainedFileCountLimit: 30,
              rollOnFileSizeLimit: true,
              shared: true,
              flushToDiskInterval: TimeSpan.FromSeconds(1))
           .CreateLogger();
            try
            {
                Log.Information("Project Started");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            { 
                Log.Error(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
