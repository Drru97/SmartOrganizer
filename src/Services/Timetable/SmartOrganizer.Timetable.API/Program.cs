using Microsoft.AspNetCore.Hosting;
using SmartOrganizer.Timetable.API.Infrastructure;
using SmartOrganizer.WebHost.Customization;

namespace SmartOrganizer.Timetable.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<TimetableContext>(context =>
                {
                    new TimetableContextSeed()
                        .SeedAsync(context)
                        .Wait();
                })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:8001")
                .Build();
    }
}
