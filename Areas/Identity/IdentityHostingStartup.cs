using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcTprm.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MvcTprm.Areas.Identity.IdentityHostingStartup))]
namespace MvcTprm.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MvcTprmIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MvcTprmIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<MvcTprmIdentityDbContext>();
            });
        }
    }
}