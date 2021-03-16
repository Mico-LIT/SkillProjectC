using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_ConfigurationType
{
    public class Startup
    {
        public IConfiguration AppConfiguration { get; set; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(hostEnvironment.ContentRootPath);

            //Json
            configurationBuilder.AddJsonFile("appsettings.Development.json");
            //Ini
            configurationBuilder.AddIniFile("ConfigIni.ini");
            //XML
            configurationBuilder.AddXmlFile("XMLFile.xml");
            //AddInMemoryCollection
            configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "GuidTokenMemory",Guid.NewGuid().ToString()},
                { "ColorMemory","Red" }
            });

            AppConfiguration = configurationBuilder.Build();
        }

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

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var str = new StringBuilder();
                    context.Response.ContentType = "text/html";
                    foreach (RouteEndpoint rout in endpoints.DataSources.First().Endpoints)
                        str.Append($"<a href=\"{rout.RoutePattern.RawText}\">{rout.DisplayName}</a> </br>");

                    await context.Response.WriteAsync($"{str}");
                });

                endpoints.MapGet("/AddJsonFile", async context =>
                {
                    var str = new StringBuilder();
                    context.Response.ContentType = "text/html";

                    str.Append($"<h2>GuidToken: {AppConfiguration["GuidToken"]}</h2>");

                    IConfiguration logLevelConfig = AppConfiguration.GetSection("Logging").GetSection("LogLevel");

                    foreach (var item in logLevelConfig.GetChildren())
                        str.Append($"<h2>{item.Key}: {item.Value}</h2>");

                    await context.Response.WriteAsync(str.ToString());
                });

                endpoints.MapGet("/MemoryCollection", async context =>
                {
                    context.Response.ContentType = "text/html";

                    string response = $"GuidTokenMemory: {AppConfiguration["GuidTokenMemory"]} | " +
                                      $"ColorMemory: {AppConfiguration["ColorMemory"]}";

                    await context.Response.WriteAsync($"<h2>{response}</h2>");
                });

                endpoints.MapGet("/AddIniFile", async context =>
                {
                    context.Response.ContentType = "text/html";

                    string response = $"ColorIni: {AppConfiguration["ColorIni"]} | " +
                    $"ContentIni: {AppConfiguration["ContentIni"]} | " +
                    $"TestINI: {AppConfiguration["TestINI"]} | ";

                    await context.Response.WriteAsync($"<h2>{response}</h2>");
                });

                endpoints.MapGet("/AddXmlFile", async context =>
                {
                    context.Response.ContentType = "text/html";

                    string response = $"ColorXML: {AppConfiguration["ColorXML"]} | " +
                    $"ContentXML: {AppConfiguration["ContentXML"]} | ";

                    await context.Response.WriteAsync($"<h2>{response}</h2>");
                });
            });
        }
    }
}
