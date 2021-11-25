using System;
using BoysAndGirls8.Areas.Identity.Data;
using BoysAndGirls8.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BoysAndGirls8.Areas.Identity.IdentityHostingStartup))]
namespace BoysAndGirls8.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BoysAndGirlsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BoysAndGirlsContextConnection")));

                services.AddDefaultIdentity<BoysAndGirls8User>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<BoysAndGirlsContext>();
            });
        }
    }
}