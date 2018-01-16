using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Talk1Samples
{
    public class SlowController : Controller
    {
        [Route("/slow-async")]
        public Task SlowAsync()
        {
            return Task.Delay(TimeSpan.FromMinutes(3));
        }

        [Route("/slow-sync")]
        public void SlowSync()
        {
            Thread.Sleep(TimeSpan.FromMinutes(3));
        }

        [Route("/slow-async-over-async")]
        public void SlowSyncOverAsync()
        {
            Task.Delay(TimeSpan.FromMinutes(3)).Wait();
        }
    }
}
