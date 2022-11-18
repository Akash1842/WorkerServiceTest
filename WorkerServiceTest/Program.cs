using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerServiceTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                }).
                UseNLog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
