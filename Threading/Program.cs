using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Threading
{
    public class Program
    {
        public static int Requests;

        public static void Main(string[] args)
        {
            new Thread(ShowThreadStats)
            {
                IsBackground = true
            }.Start();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5000")
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Critical);
                })
                .Build();

        private static void ShowThreadStats(object obj)
        {
            ThreadPool.SetMaxThreads(50, 100);

            while (true)
            {
                ThreadPool.GetAvailableThreads(out var workerThreads, out var _);
                ThreadPool.GetMinThreads(out var minThreads, out var _);
                ThreadPool.GetMaxThreads(out var maxThreads, out var _);

                Console.WriteLine($"Avail: {workerThreads}, Min: {minThreads}, Max: {maxThreads}, Req: {Requests}");

                Thread.Sleep(1000);
            }
        }
    }
}
