using AutoMapper;
using ShortenUrl.DataContracts;
using ShortenUrl.Services.Interfaces;
using ShortenUrl.Services.Mappings;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Model = ShortenUrl.Services.Models;

namespace ShortenUrlWebHost.Controllers
{
    /// <summary>
    /// API for URL management
    /// </summary>
    [RoutePrefix("api/urls")]
    public class UrlApiController : ApiController
    {
        private readonly IShortenUrlService _shotenUrlService;
        private readonly IMapper _mapper;

        public UrlApiController(IShortenUrlService shotenUrlService, IMapper mapper)
        {
            _shotenUrlService = shotenUrlService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all URL entries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var models = await _shotenUrlService.GetAllAsync();
            var dtos = _mapper.MapList<ShortenUrlDto>(models);
            return Ok(dtos);
        }

        /// <summary>
        /// Get Shorten URL by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var model = await _shotenUrlService.GetAsync(id);
            var dto = _mapper.Map<ShortenUrlDto>(model);
            return Ok(dto);
        }

        /// <summary>
        /// Get URL entry by shortcut
        /// </summary>
        /// <param name="shortcut"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{shortcut}")]
        public async Task<IHttpActionResult> Get(string shortcut)
        {
            var model = await _shotenUrlService.GetAsync(shortcut);
            var dto = _mapper.Map<ShortenUrlDto>(model);
            return Ok(dto);
        }

        /// <summary>
        /// Create new URL entry
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody] ShortenUrlDto dto)
        {
            var model = _mapper.Map<Model.ShortenUrl>(dto);
            var id = await _shotenUrlService.CreateAsync(model);
            return Ok(id);
        }

        /// <summary>
        /// Update existing URL entry
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> Update([FromBody] ShortenUrlDto dto)
        {
            var model = _mapper.Map<Model.ShortenUrl>(dto);
            await _shotenUrlService.UpdateAsync(model);
            return Ok();
        }

        /// <summary>
        /// Delete Shorten URL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            await _shotenUrlService.DeleteAsync(id);
            return Ok();
        }
    }
}
