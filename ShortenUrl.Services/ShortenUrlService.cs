using AutoMapper;
using ShortenUrl.Services.Helpers.Interfaces;
using ShortenUrl.Services.Infrastructure.Interfaces;
using ShortenUrl.Services.Interfaces;
using ShortenUrl.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using EF = ShortenUrl.EntityFramework.Models;

namespace ShortenUrl.Services
{
    public class ShortenUrlService : IShortenUrlService
    {
        private readonly IShortenUrlRepository _repo;
        private readonly IMapper _mapper;
        private readonly IValidationHelper _validator;

        public ShortenUrlService(IShortenUrlRepository repo, IMapper mapper, IValidationHelper validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<Guid> CreateAsync(Models.ShortenUrl model)
        {
            await Validate(model);
            var efModel = _mapper.Map<EF.ShortenUrl>(model);
            return await _repo.CreateAsync(efModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Models.ShortenUrl>> GetAllAsync()
        {
            var items = await _repo.GetAll().ToListAsync();
            return _mapper.MapList<Models.ShortenUrl>(items);
        }

        public async Task<Models.ShortenUrl> GetAsync(Guid id)
        {
            var item = await _repo.GetAsync(id);
            return _mapper.Map<Models.ShortenUrl>(item);
        }

        public async Task<Models.ShortenUrl> GetAsync(string shortcut)
        {
            var item = await _repo.GetAsync(shortcut);
            return _mapper.Map<Models.ShortenUrl>(item);
        }

        public async Task UpdateAsync(Models.ShortenUrl model)
        {
            await Validate(model);
            var efModel = _mapper.Map<EF.ShortenUrl>(model);
            await _repo.UpdateAsync(efModel);
        }

        private async Task Validate(Models.ShortenUrl model)
        {
            var shortcutValid = await _validator.IsShortcutValidAsync(model.Shortcut);
            if (!shortcutValid)
            {
                throw new ArgumentException("Shortcut is already used");
            }

            var urlValid = await _validator.IsUrlValidAsync(model.Url);
            if (!urlValid)
            {
                throw new ArgumentException("Url is not valid");
            }
        }
    }
}
