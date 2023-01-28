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
                    new Platform() { Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), Name = "Sql Server", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Id = new Guid("c9cd4c053-49b6-410c-bc78-2d54a9991176"), Name = "Kubernetes", Publisher = "Cloud native computation foundation", Cost = "Free"}
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
