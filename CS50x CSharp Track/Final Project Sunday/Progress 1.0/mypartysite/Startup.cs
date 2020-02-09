using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using mypartysite.Model;
using Microsoft.Extensions.Caching.Memory;

namespace mypartysite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            using(var client = new DatabaseContext())
            {
                client.Database.EnsureCreated();
            }
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //register database service
            services.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>();

            //register session  https://www.mikesdotnetting.com/article/270/sessions-in-asp-net-core  || https://forums.asp.net/t/2097262.aspx?+services+AddCaching+and+app+UseSession+not+working
            services.AddMemoryCache();
            services.AddSession(options => { 
            options.IdleTimeout = TimeSpan.FromMinutes(30); 
            options.CookieName = ".MyCookie";
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
