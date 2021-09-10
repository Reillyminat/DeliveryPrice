using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace DeliveryService.API.Filters
{
    public class CustomExceptionAttribute : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionAttribute> _logger;

        public CustomExceptionAttribute(ILogger<CustomExceptionAttribute> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError("LogError {0}, stack trace: {1}", context.Exception.Message, context.Exception.StackTrace);
        }

    }
}
