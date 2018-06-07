using ShortenUrl.Services.Helpers.Interfaces;
using ShortenUrl.Services.Infrastructure.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace ShortenUrl.Services.Helpers
{
    public class ValidationHelper : IValidationHelper
    {
        private readonly IShortenUrlRepository _repo;

        public ValidationHelper(IShortenUrlRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> IsShortcutValidAsync(string shortcut)
        {
            var item = await _repo.GetAsync(shortcut);
            return item == null;
        }

        public async Task<bool> IsUrlValidAsync(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}
