using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Middleware
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
            //_01_Example_CustomMiddelware(app, env);
            //_02_Example_Pipeline_Run(app, env);
            //_03_Example_HealthCheck(app, env);
            //_04_Example_Map(app, env);
            //_05_Example_Use(app, env);
            //_06_Example_MentodNext(app, env);
            //_07_Example_OnStarting(app, env);
            _08_Example_CustomMiddelware(app, env);
        }
        private void _01_Example_CustomMiddelware(IApplicationBuilder app, IWebHostEnvironment env)
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

        private void _02_Example_Pipeline_Run(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // метод run создает простой middelware который всегда возвращает ответ
            // context (HttpContext) это объект который содержит данные ответа и запроса
            // этот middelware не передает данные след компанентам pipeline
            app.Run(async (context) =>
            {
                string userAgent = context.Request.Headers["User-Agent"];
                await context.Response.WriteAsync($"Hi you use :{userAgent}");
            });

            // сюда запрос не попадет
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Only run meyhod");
            });
        }

        private void _03_Example_HealthCheck(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.Map("/health-check", branch =>
            {
                branch.UseExceptionHandler("/Error");

                branch.Run(async (context) =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("True");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("HI!");
            });
        }

        private void _04_Example_Map(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Метод Map модифицирует ветку запроса и отризает первый сегмент
            app.Map("/Path1", branch =>
            {
                branch.Run(async (context) =>
                {
                    // path     = "/home/index"
                    // pathBase = "/Path1"

                    string path = context.Request.Path;
                    string pathBase = context.Request.PathBase;

                    await context.Response.WriteAsync($"/Path1 Branch path: {path} pathBase: {pathBase}");
                });
            });

            app.Map("/path2/path3", branch =>
            {
                branch.Run(async (context) =>
                {
                    string path = context.Request.Path;
                    string pathBase = context.Request.PathBase;

                    await context.Response.WriteAsync($"/path2 Branch path: {path} pathBase: {pathBase}");
                });
            });

            app.Run(async (context) =>
                {
                    string path = context.Request.Path;
                    string pathBase = context.Request.PathBase;

                    await context.Response.WriteAsync($"Main path: {path} pathBase: {pathBase}");
                });

        }

        private void _05_Example_Use(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                Debug.WriteLine("Use1 before next");
                await next(); // Вызов след Middelware
                Debug.WriteLine("Use1 after next");
            });
            app.Use(async (context, next) =>
            {
                Debug.WriteLine("Use2 before next");
                await next();// Вызов след Middelware
                Debug.WriteLine("Use2 after next");
            });
            app.Use(async (context, next) =>
            {
                Debug.WriteLine("Use3"); // Цепочка на этом прирываеться
                //await next();
            });
        }

        private void _06_Example_MentodNext(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("CustomHeader", Guid.NewGuid().ToString());
                await next();
                // Выполнять изменение ответа после метода next() запрещено
                //context.Response.Headers.Add("CustomHeader", Guid.NewGuid().ToString());
            });

            app.Run(async context => await context.Response.WriteAsJsonAsync("_06_Example"));
        }

        private void _07_Example_OnStarting(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.Use(async (context, next) =>
            {
                // должна выполниться перед отправкой загаловок клиету
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("CustomHeader", Guid.NewGuid().ToString());
                    return Task.CompletedTask;
                });

                await next();
            });

            app.Run(async context => await context.Response.WriteAsJsonAsync("_07_Example"));
        }

        private void _08_Example_CustomMiddelware(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseMiddleware<CustomMiddelware>();
        }

    }
}
