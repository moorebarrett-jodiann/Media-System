using Microsoft.EntityFrameworkCore;

namespace MusicSystem.Data
{
    public static class SeedData
    {
        public async static Task Initialize (IServiceProvider serviceProvider)
        {
            DBContext context = new DBContext(serviceProvider.GetRequiredService<DbContextOptions<DBContext>>());

            // set db initialization strategies
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            // seed data

            // save to db
            await context.SaveChangesAsync();

        }
    }
}
