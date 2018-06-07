using AutoMapper;
using Domain = ShortenUrl.Services.Models;
using EF = ShortenUrl.EntityFramework.Models;

namespace ShortenUrl.Services.Mappings
{
    public class DataEntityVsDomainMappingProfile : Profile
    {
        public DataEntityVsDomainMappingProfile()
        {
            CreateMap<EF.ShortenUrl, Domain.ShortenUrl>();
            CreateMap<Domain.ShortenUrl, EF.ShortenUrl>();
        }
    }
}
