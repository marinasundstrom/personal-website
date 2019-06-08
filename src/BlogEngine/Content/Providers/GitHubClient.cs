using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlogEngine.Configuration;
using Newtonsoft.Json;

namespace BlogEngine.Content.Providers
{
    public interface IGitHubClient
    {
        Task<IEnumerable<Content>> GetContentAsync(string path);
        Task<string> GetRawContentAsync(string path);
    }

    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfigurationManager configurationManager;

        public GitHubClient(
            HttpClient httpClient,
            IConfigurationManager configuration)
        {
            this.httpClient = httpClient;
            this.configurationManager = configuration;
        }

        public async Task<string> GetRawContentAsync(string path)
        {
            var configuration = configurationManager.Configuration;
            var contentUri = GetUserRawContentUri(
                configuration.GetSection("GitHub").GetValue<string>("User"), 
                configuration.GetSection("GitHub").GetValue<string>("Repository"), 
                configuration.GetSection("GitHub").GetValue<string>("Branch"), path);

            return await httpClient.GetStringAsync(contentUri);
        }

        public async Task<IEnumerable<Content>> GetContentAsync(string path)
        {

            var configuration = configurationManager.Configuration;
            var contentUri = GetUserContentUri(
                configuration.GetSection("GitHub").GetValue<string>("User"),
                configuration.GetSection("GitHub").GetValue<string>("Repository"), path);

            var content = await httpClient.GetStringAsync(contentUri);
            return JsonConvert.DeserializeObject<Content[]>(content);
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

    public class Content
    {
        public string type { get; set; }
        public string encoding { get; set; }
        public int size { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string content { get; set; }
        public string sha { get; set; }
        public string url { get; set; }
        public string git_url { get; set; }
        public string html_url { get; set; }
        public string download_url { get; set; }
        public _Links _links { get; set; }
    }

    public class _Links
    {
        public string git { get; set; }
        public string self { get; set; }
        public string html { get; set; }
    }

}
