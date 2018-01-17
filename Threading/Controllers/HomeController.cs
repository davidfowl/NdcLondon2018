using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Threading.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/hello")]
        public string Hello()
        {
            Thread.Sleep(2000);

            return "Hello World";
        }

        [HttpGet("/hello-sync-over-async")]
        public string HelloSyncOverAsync()
        {
            Task.Delay(2000).Wait();

            return "Hello World";
        }

        [HttpGet("/hello-async-over-sync")]
        public async Task<string> HelloAsyncOverSync()
        {
            await Task.Run(() => Thread.Sleep(2000));

            return "Hello World";
        }

        [HttpGet("/hello-async")]
        public async Task<string> HelloAsync()
        {
            await Task.Delay(2000);

            return "Hello World";
        }
    }
}
