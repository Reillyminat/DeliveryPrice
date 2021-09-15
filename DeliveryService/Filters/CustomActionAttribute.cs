using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Text;

namespace DeliveryService.API.Filters
{
    public class CustomActionAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var bodyStr = string.Empty;
            var requestBody = context.HttpContext.Request.Body;
            using var reader = new StreamReader(requestBody, Encoding.UTF8, true, 1024, true);
            bodyStr = reader.ReadToEnd();
            Console.WriteLine("Request body: {0}", bodyStr);
        }
    }
}