using BlogEngine.Content.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine
{
    public static class BlogSiteOptionsExtensions 
    {
        public static BlogSiteOptions AddGitHubProvider(this BlogSiteOptions options) 
        {
            options.ServiceCollection.AddSingleton<IGitHubClient, GitHubClient>();
            options.ContentProvider = typeof(GitHubContentProvider);
            return options;
        }
    }
}
