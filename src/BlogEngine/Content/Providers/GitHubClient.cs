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
        Task<IEnumerable<CommitDto>> GetCommitsAsync(string path);
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
            return GetUri(user, repository, $"contents/{contentPath}");
        }

        private static string GetUri(string user, string repository, string path)
        {
            return $"https://api.github.com/repos/{user}/{repository}/{path}";
        }

        public async Task<IEnumerable<CommitDto>> GetCommitsAsync(string path)
        {

            var configuration = configurationManager.Configuration;
            var contentUri = GetUri(
                configuration.GetSection("GitHub").GetValue<string>("User"),
                configuration.GetSection("GitHub").GetValue<string>("Repository"), $"commits?path={path}");

            var content = await httpClient.GetStringAsync(contentUri);
            return JsonConvert.DeserializeObject<CommitDto[]>(content);
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

    public partial class CommitDto
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("comments_url")]
        public Uri CommentsUrl { get; set; }

        [JsonProperty("commit")]
        public Commit Commit { get; set; }

        [JsonProperty("author")]
        public WelcomeAuthor Author { get; set; }

        [JsonProperty("committer")]
        public WelcomeAuthor Committer { get; set; }

        [JsonProperty("parents")]
        public Tree[] Parents { get; set; }
    }

    public partial class WelcomeAuthor
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url")]
        public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url")]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url")]
        public string GistsUrl { get; set; }

        [JsonProperty("starred_url")]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url")]
        public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url")]
        public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url")]
        public Uri ReposUrl { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("received_events_url")]
        public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }
    }

    public partial class Commit
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("author")]
        public CommitAuthor Author { get; set; }

        [JsonProperty("committer")]
        public CommitAuthor Committer { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tree")]
        public Tree Tree { get; set; }

        [JsonProperty("comment_count")]
        public long CommentCount { get; set; }

        [JsonProperty("verification")]
        public Verification Verification { get; set; }
    }

    public partial class CommitAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public partial class Tree
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }
    }

    public partial class Verification
    {
        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("signature")]
        public object Signature { get; set; }

        [JsonProperty("payload")]
        public object Payload { get; set; }
    }
}
