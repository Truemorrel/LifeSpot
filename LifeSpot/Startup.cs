using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Загружаем отдельные элементы для вставки в шаблон: боковое меню и футер
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sideBar.html"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Static/JavaScript/index.js", async context =>
                {
                var indexJsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JavaScript", "index.js");
                var ijs = await File.ReadAllTextAsync(indexJsPath);
                await context.Response.WriteAsync(ijs);
                });

                endpoints.MapGet("/Static/JavaScript/testing.js", async context =>
                {
                var testJsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JavaScript", "testing.js");
                var tjs = await File.ReadAllTextAsync(testJsPath);
                await context.Response.WriteAsync(tjs);
                });

                endpoints.MapGet("/Static/JavaScript/about.js", async context =>
                {
                    var aboutJsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JavaScript", "about.js");
                    var ajs = await File.ReadAllTextAsync(aboutJsPath);
                    await context.Response.WriteAsync(ajs);
                });

                endpoints.MapGet("/Static/CSS/index.css", async context =>
                
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", "index.css");
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });

                endpoints.MapGet("/", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                    
                    // Загружаем шаблон страницы, вставляя в него элементы
                    
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                    
                    await context.Response.WriteAsync(html.ToString());
                });

                endpoints.MapGet("/testing", async context =>
                {
                    var viewTestPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");
                    
                    // Загружаем шаблон страницы, вставляя в него элементы
                    
                    var testingPath = new StringBuilder(await File.ReadAllTextAsync(viewTestPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                    
                    await context.Response.WriteAsync(testingPath.ToString());
                });
                
                endpoints.MapGet("/about", async context =>
                {
                    var viewAboutPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");

                    
                    // Загружаем шаблон страницы, вставляя в него элементы
                    
                    var about = new StringBuilder(await File.ReadAllTextAsync(viewAboutPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);

                    
                    await context.Response.WriteAsync(about.ToString());
                });
            });
        }
    }
}