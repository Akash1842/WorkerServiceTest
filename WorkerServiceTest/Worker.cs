using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServiceTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync (CancellationToken stoppingToken)
        {
            await DoWork(stoppingToken);
        }

        protected async Task DoWork(CancellationToken stoppingToken)
        {
            //string path = @"c:\temp\MyTest.txt";
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to.
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("Hello");
            //        sw.WriteLine("And");
            //        sw.WriteLine("Welcome");
            //    }
            //}
            //else
            //{
            //    using (StreamWriter sw = File.AppendText(path))
            //    {
            //        sw.WriteLine("This");
            //        sw.WriteLine("is Extra");
            //        sw.WriteLine("Text");
            //    }
            //}

            while (!stoppingToken.IsCancellationRequested)
            {

                //sw.WriteLine("Worker running at: {time}", DateTimeOffset.Now);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
