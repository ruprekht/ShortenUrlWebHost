using ShortenUrl.EntityFramework;
using System.Data.Entity;

namespace ShortenUrl.Services.Infrastructure
{
    public class ShortenUrlDbInitializer : CreateDatabaseIfNotExists<EntityDbContext>
    {
        protected override void Seed(EntityDbContext context) { }
    }
}
