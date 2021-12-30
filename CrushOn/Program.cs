using System;
using System.Linq;
using CrushOn.Core.EntitiesModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrushOn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                // Get the instance of CrushOnContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CrushOnContext>();

                // Call the DataGenerator to create sample data
                DataGenerator.Initialize(services);
                host.Run();

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CrushOnContext(
                serviceProvider.GetRequiredService<DbContextOptions<CrushOnContext>>()))
            {
                // Look for any board games.
                if (context.Sellers.Any())
                {
                    return;   // Data was already seeded
                }

                context.Sellers.AddRange(
                    new SellerModel
                    {
                        Id = 1,
                        StoreName = "American Vintage",
                        Email = "americanvintage@gmail.com"
                    });
                context.SaveChanges();
            }
        }
    }
}


