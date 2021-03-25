using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace _005_Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Сервис маршрутизации. 'шаблон' {Controller}/{Action} 
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            RouteBuilder routeBuilder;

            //_01_Example(app, out routeBuilder);
            //_02_Example(app, out routeBuilder);
            //_03_Example(app, out routeBuilder);
            //_04_Example(app, out routeBuilder);
            //_05_Example(app, out routeBuilder);

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync("<h1>Default page</h1>");

                var str = new StringBuilder();
                foreach (Route route in routeBuilder.Routes)
                    str.Append($"<a href=\"{route.RouteTemplate}\">{route.RouteTemplate}</a> </br>");

                await context.Response.WriteAsync($"{str}");

            });
        }

        private void _01_Example(IApplicationBuilder app, out RouteBuilder routeBuilder)
        {
            routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("Home", async (context) =>
            {
                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync("<h1>Home</h1>");
            });

            routeBuilder.MapRoute("Home/CurrentProducts", async (context) =>
            {
                context.Response.ContentType = "text/html";

                StringCollection strColl = new StringCollection()
                {
                    "Cucumber",
                    "Milk",
                    "Bread",
                };

                await context.Response.WriteAsync("<h1>Avalible products:</h1>");

                foreach (var item in strColl)
                    await context.Response.WriteAsync($"{item}</br>");

            });
        }

        private void _02_Example(IApplicationBuilder app, out RouteBuilder routeBuilder)
        {
            routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("{Controller}", async (context) =>
            {
                await context.Response.WriteAsync("{Controller} temlpated use");
            });

            routeBuilder.MapRoute("{Controller}/{Action}", async (context) =>
            {
                await context.Response.WriteAsync("{Controller}/{Action} temlpated use");
            });

        }

        private void _03_Example(IApplicationBuilder app, out RouteBuilder routeBuilder)
        {
            routeBuilder = new RouteBuilder(app);

            var routeHandlerHome = new RouteHandler(async (context) =>
            {
                await context.Response.WriteAsync("<h1>_03_Example HandlerHome</h1>");
            });

            var routeHandlerHomeCurrentProducts = new RouteHandler(async (context) =>
            {
                await context.Response.WriteAsync("<h1>_03_Example HandlerHomeCurrentProducts</h1>");
            });

            var routeBuilderHome = new RouteBuilder(app, routeHandlerHome);
            var routeBuilderHomeCurrentProducts = new RouteBuilder(app, routeHandlerHomeCurrentProducts);

            // определение маршрутов - они должны соответствовать заданным статическим шаблонам
            routeBuilderHome.MapRoute("default", "Home");
            routeBuilderHomeCurrentProducts.MapRoute("default", "Home/CurrentProducts");

            app.UseRouter(routeBuilderHome.Build());
            app.UseRouter(routeBuilderHomeCurrentProducts.Build());

            // В контексте одного routeBuilder заюзать маршрут с одиним и тем же именем нельзя! один и тот же ключ (default)
            // Исключение NULL
            //foreach (var item in routeBuilderHome.Routes)
            //    routeBuilder.Routes.Add(item);
            //foreach (var item in routeBuilderHomeCurrentProducts.Routes)
            //    routeBuilder.Routes.Add(item);

        }

        private void _04_Example(IApplicationBuilder app, out RouteBuilder routeBuilder)
        {
            routeBuilder = new RouteBuilder(app);

            // Порядок маршрута важен
            // Если поменять местами маршрут Test/{Controller}/{Action}/{id} не вызовиться
            routeBuilder.MapRoute("Test/{Action}/{id}", async (context) =>
            {
                await context.Response.WriteAsync("Test/{Controller}/{Action}/{id}");
            });

            // Общие шаблоны должны обрабатываться в самую последнюю очередь
            routeBuilder.MapRoute("{Controller=Home}/{Action}/{id}", async (context) =>
            {
                await context.Response.WriteAsync("{Controller=Home}/{Action}/{id}");
            });
        }

        private void _05_Example(IApplicationBuilder app, out RouteBuilder routeBuilder)
        {
            routeBuilder = new RouteBuilder(app);

            // не обязательный параметр {id?}
            routeBuilder.MapRoute("{Controller}/{Action}/{id?}", async (context) =>
            {
                await context.Response.WriteAsync("{Controller}/{Action}/{id?}");
            });

            // множественные параметры 
            routeBuilder.MapRoute("{Controller}/{Action}/{id}/{*catchall}", async (context) =>
            {
                await context.Response.WriteAsync("{Controller}/{Action}/{id}/{*catchall}");
            });
        }

    }
}
