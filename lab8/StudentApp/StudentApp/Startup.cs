using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StudentApp
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHost { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHost)
        {
            Configuration = configuration;
            WebHost = webHost;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<StudentContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("StudentConStr"))
            );

            services.AddControllersWithViews();
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
                endpoints.MapControllerRoute
               (
                   name: "myOwnRoute",
                   pattern: "{Controller=Students}/{Action=Index}/{id?}"
               );
            });
           

            app.UseStaticFiles();
        }
    }
}
