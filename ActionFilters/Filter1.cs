using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace ActionFilter1.ActionFilters
{
    public class Filter1 : IActionFilter
    {
        Stopwatch sw = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {

            context.HttpContext.Response.Headers.Add("Execution-Time", sw.Elapsed.ToString());
            context.HttpContext.Response.Headers.Add("HTTP-Method", context.HttpContext.Request.Method);
            context.HttpContext.Response.Headers.Add("HTTP-Scheme", context.HttpContext.Request.Scheme);
            context.HttpContext.Response.Headers.Add("Action-Name", context.ActionDescriptor.DisplayName);
            context.HttpContext.Response.Headers.Add("Host", context.HttpContext.Request.Host.ToString());
            context.HttpContext.Response.Headers.Add("Port", context.HttpContext.Request.Host.Port.ToString());
            context.HttpContext.Response.Headers.Add("Server-Time", DateTime.Now.ToString());

            sw.Stop();

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            sw.Start();
        }
    }
}
