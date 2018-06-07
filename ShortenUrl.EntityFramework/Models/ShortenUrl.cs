using System.ComponentModel.DataAnnotations;

namespace ShortenUrl.EntityFramework.Models
{
    public class ShortenUrl : BaseEntityGuid
    {
        [Required(ErrorMessage = "Shortcut is required.")]
        public string Shortcut { get; set; }
        [Required(ErrorMessage = "URL is required.")]
        public string Url { get; set; }
    }
}
