using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickAndPlay.Areas.Identity.Data;

[assembly: HostingStartup(typeof(PickAndPlay.Areas.Identity.IdentityHostingStartup))]
namespace PickAndPlay.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PickAndPlayIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PickAndPlayIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PickAndPlayIdentityContext>();
            });
        }
    }
}