using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace DeliveryService.API.Filters
{
    public class CustomActionAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("QueryString: {0}", context.HttpContext.Request.QueryString.Value);
        }
    }
}
