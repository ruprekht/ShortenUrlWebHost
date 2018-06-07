using ShortenUrl.EntityFramework;
using ShortenUrl.Services.Infrastructure.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EF = ShortenUrl.EntityFramework.Models;

namespace ShortenUrl.Services.Infrastructure.Repositories
{
    public class ShortenUrlRepository : IShortenUrlRepository, IDisposable
    {
        private readonly EntityDbContext _context;

        public ShortenUrlRepository(IDbContextProvider provider)
        {
            _context = provider.Context;
        }

        public async Task<Guid> CreateAsync(EF.ShortenUrl model)
        {
            var item = _context.ShortenUrls.Add(model);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.ShortenUrls.FindAsync(id);
            _context.ShortenUrls.Remove(item);
            await _context.SaveChangesAsync();
        }

        public IQueryable<EF.ShortenUrl> GetAll()
        {
            return _context.ShortenUrls.AsQueryable();
        }

        public async Task<EF.ShortenUrl> GetAsync(Guid id)
        {
            var item = await _context.ShortenUrls.FindAsync(id);
            return item;
        }

        public async Task<EF.ShortenUrl> GetAsync(string shortcut)
        {
            var item = await _context.ShortenUrls.FirstOrDefaultAsync(x => x.Shortcut == shortcut);
            return item;
        }

        public async Task UpdateAsync(EF.ShortenUrl model)
        {
            var item = await _context.ShortenUrls.FindAsync(model.Id);
            item.Shortcut = model.Shortcut;
            item.Url = model.Url;
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
