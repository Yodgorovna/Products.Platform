using Microsoft.EntityFrameworkCore;
using Products.DataAccess.DbContexts;

namespace Products.WebApi.Configurations.Extensions
{
    public static class DataExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }
        }
    }
}
