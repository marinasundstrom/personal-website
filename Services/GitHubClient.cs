using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace PersonalSite.Services
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfigurationService configurationService;

        public GitHubClient(
            HttpClient httpClient,
            IConfigurationService configurationService)
        {
            this.httpClient = httpClient;
            this.configurationService = configurationService;
        }

        public async Task<string> GetRawContentAsync(string slug)
        {
            var configuration = await configurationService.GetConfigurationAsync();
            var contentUri = GetUserRawContentUri(configuration.GitHub.User, configuration.GitHub.Repository, configuration.GitHub.Branch, slug);
            return await httpClient.GetStringAsync(contentUri);
        }

        public async Task<IEnumerable<Content>> GetContentAsync(string slug)
        {
            var configuration = await configurationService.GetConfigurationAsync();
            var contentUri = GetUserContentUri(configuration.GitHub.User, configuration.GitHub.Repository, slug);
            var content = await httpClient.GetStringAsync(contentUri);
            return Json.Deserialize<Content[]>(content);
        }

        private static string GetUserRawContentUri(string user, string repository, string branch, string contentPath)
        {
            return $"https://raw.githubusercontent.com/{user}/{repository}/{branch}/{contentPath}";
        }

        private static string GetUserContentUri(string user, string repository, string contentPath)
        {
            return $"https://api.github.com/repos/{user}/{repository}/contents/{contentPath}";
        }
    }

}
