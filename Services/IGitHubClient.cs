using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalSite.Services
{
    public interface IGitHubClient
    {
        Task<IEnumerable<Content>> GetContentAsync(string slug);
        Task<string> GetRawContentAsync(string slug);
    }
}