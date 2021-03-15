using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Example
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware
            app.UseMiddleware<CustomMiddelware>();

            // Можно поменять (Конвеер обработки запросов) порядок и разрешить доступ к файлам без аутентификации!

            // Аутентификация пользователя на основе куки
            //app.UseAuthentication();
            // Установка обработчика статических файлов
            app.UseStaticFiles();

            // Логика обработки запроса
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hi");
            });

        }
    }
}
