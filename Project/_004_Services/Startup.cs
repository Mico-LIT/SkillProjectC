using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _004_Services
{
    public class Startup
    {
        IServiceCollection services;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // LifeTime
            //services.AddTransient<ITimeService, TimeServiceFull>();
            //services.AddScoped<ITimeService, TimeServiceFull>();
            //services.AddSingleton<ITimeService, TimeServiceFull>();

            services.AddTransient<ITimeService, TimeServiceFull>();
            this.services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITimeService timeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                context.Request.ContentType = "text/html";
                var result = new System.Text.StringBuilder();


                result.Append($"<h1>{timeService.GetTime()}</h1>");
                result.Append("<h1 alig='center'>Services</h1>");

                result.Append("<table>");
                result.Append("<tr><th>ServiceType</th><th>LifeTime</th><th>ImplementationType</th></tr>");

                foreach (var item in services)
                {
                    result.Append("<tr>");
                    result.Append($"<td style='text-align: center;'>{item.ServiceType.FullName}</td>");
                    result.Append($"<td style='text-align: center;'>{item.Lifetime}</td>");
                    result.Append($"<td style='text-align: center;'>{item.ImplementationType?.FullName ?? "EMPTY"}</td>");
                    result.Append("</tr>");
                }

                result.Append("</table>");

                await context.Response.WriteAsync(result.ToString());
            });
        }
    }
}
