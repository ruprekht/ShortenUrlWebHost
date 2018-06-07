using System.Data.Entity;

namespace ShortenUrl.EntityFramework
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext() : base("name=EntityDbContext")
        { }

        public DbSet<Models.ShortenUrl> ShortenUrls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
