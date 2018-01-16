using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Talk1Samples.Controllers
{
    public class ParallelAccessListController : Controller
    {
        [HttpGet("/parallel-list")]
        public Task ParallelAsync()
        {
            var list = new List<int>();

            var tasks = new Task[10];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = GetNumberAsync(list, i);
            }

            return Task.WhenAll(tasks);
        }

        private async Task GetNumberAsync(List<int> results, int number)
        {
            await Task.Delay(300);

            results.Add(number);
        }
    }
}
