using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Talk1Samples
{
    public class ParallelAccessController : Controller
    {
        private readonly ILogger<ParallelAccessController> _logger;

        public ParallelAccessController(ILogger<ParallelAccessController> logger)
        {
            _logger = logger;
        }

        [Route("/parallel")]
        public async Task<string> ParallelAccess()
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
                _logger.LogInformation("Before {url}:{contenttype}", url, Request.ContentType);

                await Task.Delay(100);
            }
            finally
            {
                _logger.LogInformation("After {url}:{contenttype}", url, Request.ContentType);
            }
        }
    }
}
