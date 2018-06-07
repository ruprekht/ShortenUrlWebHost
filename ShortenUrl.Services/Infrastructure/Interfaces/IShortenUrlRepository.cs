using System;
using System.Linq;
using System.Threading.Tasks;
using EF = ShortenUrl.EntityFramework.Models;

namespace ShortenUrl.Services.Infrastructure.Interfaces
{
    public interface IShortenUrlRepository
    {
        IQueryable<EF.ShortenUrl> GetAll();
        Task<EF.ShortenUrl> GetAsync(Guid id);
        Task<EF.ShortenUrl> GetAsync(string shortcut);
        Task<Guid> CreateAsync(EF.ShortenUrl model);
        Task UpdateAsync(EF.ShortenUrl model);
        Task DeleteAsync(Guid id);
    }
}
