using Microsoft.EntityFrameworkCore;
using order_api.Models;

namespace order_api.Extensions
{
    public static class DbMigration
    {
        public static IServiceCollection AddMigrations(this IServiceCollection service, IConfiguration config)
        {
            var db = new PlotroomOrdersContext(config);
            if (db.Database.GetMigrations().Any() && db.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("Migrating db...");
                //db.Database.;
                Console.WriteLine("Migaration Done");
            }
            return service;
        }
    }
}
