using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Brewforge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
        .AddEnvironmentVariables(prefix: "ASPNETCORE_")
        .Build();
            var host = new WebHostBuilder()
          .UseConfiguration(config)
          //.UseUrls("http://*:1666") //for dev
          .UseUrls("http://*:1684")
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseIISIntegration()
          .UseStartup<Startup>()
          .Build();

            host.Run();
            
        }
    }
}
