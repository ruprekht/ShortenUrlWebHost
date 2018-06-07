using AutoMapper;
using Domain = ShortenUrl.Services.Models;
using DTO = ShortenUrl.DataContracts;

namespace ShortenUrl.Services.Mappings
{
    public class DomainVsDtoMappingProfile : Profile
    {
        public DomainVsDtoMappingProfile()
        {
            CreateMap<Domain.ShortenUrl, DTO.ShortenUrlDto>();
            CreateMap<DTO.ShortenUrlDto, Domain.ShortenUrl>();
        }
    }
}
