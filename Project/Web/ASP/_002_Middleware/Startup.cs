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
            //_01_Example(app, env);
            //_02_Example(app, env);
            _03_Example(app, env);
            //_04_Example(app, env);
            //_05_Example(app, env);
            //_06_Example(app, env);
            //_07_Example(app, env);
        }
        private void _01_Example(IApplicationBuilder app, IWebHostEnvironment env)
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

        private void _02_Example(IApplicationBuilder app, IWebHostEnvironment env)
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

        private void _03_Example(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.Map("/health-check", branch =>
            {
                branch.UseExceptionHandler("/Error");

                branch.Run(async (context) =>
                {
                    context.Response.ContentType="text/plain";
                    await context.Response.WriteAsync("True");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("HI!");
            });
        }

        private void _04_Example(IApplicationBuilder app, IWebHostEnvironment env)
        {
            throw new NotImplementedException();
        }

        private void _05_Example(IApplicationBuilder app, IWebHostEnvironment env)
        {
            throw new NotImplementedException();
        }

        private void _06_Example(IApplicationBuilder app, IWebHostEnvironment env)
        {
            throw new NotImplementedException();
        }

        private void _07_Example(IApplicationBuilder app, IWebHostEnvironment env)
        {
            throw new NotImplementedException();
        }
    }
}
