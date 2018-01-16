using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Talk1Samples
{
    public class ParallelAccessIImplicitController : Controller
    {
        private readonly IRequestLogger<ParallelAccessIImplicitController> _logger;

        public ParallelAccessIImplicitController(IRequestLogger<ParallelAccessIImplicitController> logger)
        {
            _logger = logger;
        }

        [Route("/parallel-implicit")]
        public async Task<string> ParallelAccessImplicit()
        {
            var task1 = GetAsync("www.google.com");
            var task2 = GetAsync("www.bing.com");

            await Task.WhenAll(task1, task2);

            return "Hello World";
        }

        private async Task GetAsync(string url)
        {
            try
            {
                _logger.LogInformation("Before {url}", url);

                // Fake http request
                await Task.Delay(100);
            }
            finally
            {
                _logger.LogInformation("After {url}", url);
            }
        }
    }
}
