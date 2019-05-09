using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoredemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options: options =>
                {
                    options.Listen(IPAddress.Any, 8080);
                    options.Listen(IPAddress.Any, 8443, listenOptions =>
                    {
                        listenOptions.UseHttps(new X509Certificate2("restperf.pfx", "123456"));
                    });
                })
                .UseStartup<Startup>();
    }
}
