using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoysAndGirls8.Data;

namespace BoysAndGirls8
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<BoysAndGirls8Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BoysAndGirls8Context")));
            services.AddDbContext<BoysAndGirlsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BoysAndGirlsContextConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "teacher",
                    areaName: "Teacher",
                    pattern: "Teacher/{controller=TeacherTask}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "boy",
                    areaName: "Boy",
                    pattern: "Boy/{controller=BoyTasks}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "girl",
                    areaName: "Girl",
                    pattern: "Girl/{controller=GirlTasks}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
