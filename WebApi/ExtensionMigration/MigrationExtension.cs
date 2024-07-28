using Microsoft.EntityFrameworkCore;
using Persistence.ContextDb;

namespace WebApi.ExtensionMigration
{
    public static class MigrationExtension
    {
        public static void ApplyMigration(this WebApplication application)
        {
            using var scope =application.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ZacContext>();
            dbContext.Database.Migrate();
        }
    }
}
