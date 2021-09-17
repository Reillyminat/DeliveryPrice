using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeliveryService.API.Filters
{
    public class CustomExceptionAttribute : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionAttribute> _logger;
        private readonly IWebHostEnvironment _env;

        public CustomExceptionAttribute(ILogger<CustomExceptionAttribute> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (_env.IsDevelopment())
            {
                _logger.LogError("LogError {0}, stack trace: {1}", context.Exception.Message, context.Exception.StackTrace);
            }
            else
            {
                _logger.LogError("LogError {0}", context.Exception.Message);
            }
        }
    }
}
