using System.Threading.Tasks;

namespace ShortenUrl.Services.Helpers.Interfaces
{
    public interface IValidationHelper
    {
        Task<bool> IsShortcutValidAsync(string shortcut);
        Task<bool> IsUrlValidAsync(string url);
    }
}
