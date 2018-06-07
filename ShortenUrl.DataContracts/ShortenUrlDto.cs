using System;

namespace ShortenUrl.DataContracts
{
    public class ShortenUrlDto
    {
        public Guid Id { get; set; }
        public string Shortcut { get; set; }
        public string Url { get; set; }
    }
}
