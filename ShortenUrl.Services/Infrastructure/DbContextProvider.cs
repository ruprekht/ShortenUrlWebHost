using ShortenUrl.EntityFramework;
using ShortenUrl.Services.Infrastructure.Interfaces;
using System;

namespace ShortenUrl.Services.Infrastructure
{
    public class DbContextProvider : IDbContextProvider, IDisposable
    {
        public DbContextProvider()
        {
            Context = new EntityDbContext();
        }

        public EntityDbContext Context { get; }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
