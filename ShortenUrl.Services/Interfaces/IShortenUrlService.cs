using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortenUrl.Services.Interfaces
{
    public interface IShortenUrlService
    {
        Task<IEnumerable<Models.ShortenUrl>> GetAllAsync();
        Task<Models.ShortenUrl> GetAsync(Guid id);
        Task<Models.ShortenUrl> GetAsync(string shortcut);
        Task<Guid> CreateAsync(Models.ShortenUrl model);
        Task UpdateAsync(Models.ShortenUrl model);
        Task DeleteAsync(Guid id);
    }
}
