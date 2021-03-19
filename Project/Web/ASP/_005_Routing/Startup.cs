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

            _01_Example(app, out var routeBuilder);
            //_02_Example(app);
            //_03_Example(app);
            //_04_Example(app);

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
        private void _02_Example(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }
        private void _04_Example(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }
        private void _03_Example(IApplicationBuilder app)
        {
            throw new NotImplementedException();
        }
    }
}
