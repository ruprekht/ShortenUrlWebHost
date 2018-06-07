using AutoMapper;
using System.Collections.Generic;

namespace ShortenUrl.Services.Mappings
{
    public static class MappingExtensions
    {
        public static IEnumerable<TD> MapList<TD>(this IMapper mapper, IEnumerable<object> list)
        {
            return list == null ? null : mapper.Map<IEnumerable<TD>>(list);
        }
    }
}
