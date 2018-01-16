using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Talk1Samples
{
    public class BigContentController : Controller
    {
        private readonly HttpClient _httpClient;
        private static string _url = "http://www.vizgr.org/historical-events/search.php?format=json&begin_date=-3000000&end_date=20151231&lang=en";

        public BigContentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [Route("/big-content-bad")]
        public Task<string> BigContentBad()
        {
            return _httpClient.GetStringAsync(_url);
        }

        [Route("/big-content-stillbad")]
        public async Task<string> BigContentBadAgain()
        {
            using (var response = await _httpClient.GetAsync(_url))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        [Route("/big-content-good")]
        public Task<Stream> BigContentGood()
        {
            return _httpClient.GetStreamAsync(_url);
        }
    }
}
