using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SmartOrganizer.WebHost.Customization
{
    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                try
                {
                    context.Database.Migrate();
                    seeder(context);
                }
                catch (Exception)
                {
                    // TODO: add exception handling
                    // ignored
                }
            }

            return webHost;
        }
    }
}
