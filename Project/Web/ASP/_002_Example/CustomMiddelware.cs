using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Example
{
    public class CustomMiddelware
    {
        // Ссылка на след компонент конвеера запросов
        readonly RequestDelegate next;
        private readonly ILogger logger;

        public CustomMiddelware(RequestDelegate next, ILogger<CustomMiddelware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        // Должен быть Invoke или InvokeAsync!
        public async Task InvokeAsync(HttpContext context)
        {
            var methodName = context.Request.Method;
            if (methodName == "GET")
            {
                logger.LogWarning("CustomMiddelware");

                context.Response.StatusCode = StatusCodes.Status200OK;
                await context.Response.WriteAsync("HI CustomMiddelware");
            }
            else
            {
                // передаем дальше по конвееру запросов
                await next(context);
            }
        }
    }
}
