using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Talk1Samples
{
    public interface IRequestLogger<T>
    {
        void LogInformation(string data, params object[] args);
    }

    public class RequestLogger<T> : IRequestLogger<T>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<T> _logger;

        public RequestLogger(IHttpContextAccessor contextAccessor, ILogger<T> logger)
        {
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        public void LogInformation(string data, params object[] args)
        {
            _logger.LogInformation(data + " " + _contextAccessor.HttpContext.Request.ContentType, args);
        }
    }
}
