using System;

namespace ShortenUrl.Services.Models
{
    public class ShortenUrl
    {
        public Guid Id { get; set; }
        public string Shortcut { get; set; }
        public string Url { get; set; }
    }
}
