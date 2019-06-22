using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Settings.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog.Core;
using Serilog.Formatting.Compact;

namespace WebCultureInGdansk
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
       .Build();

        public static void Main(string[] args)
        {
            var logger = Serilog.Log.Logger;
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .CreateLogger();

            try
            {
                Log.Information("Webpage started successfully");

                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

       public static IWebHost BuildWebHost(string[] args) =>
       WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>()
              .UseConfiguration(Configuration)
              .Build();
    }
}
