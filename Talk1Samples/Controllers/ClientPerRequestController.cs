using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Talk1Samples
{
    public class ClientPerRequestController : Controller
    {
        [Route("/outgoing-bad")]
        public async Task<string> OutgoingBad()
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync("http://www.google.com");
            }
        }
    }
}
