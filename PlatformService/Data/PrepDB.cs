using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
#pragma warning disable CS8604 // Possible null reference argument.
                SeedData(context);
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> No seeded data");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "Sql Server", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud native computation foundation", Cost = "Free"}
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Seeded data available");
            }
        }
    }
}
