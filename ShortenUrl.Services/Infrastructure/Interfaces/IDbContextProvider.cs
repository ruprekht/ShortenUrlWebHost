using ShortenUrl.EntityFramework;

namespace ShortenUrl.Services.Infrastructure.Interfaces
{
    public interface IDbContextProvider
    {
        EntityDbContext Context { get; }
    }
}
