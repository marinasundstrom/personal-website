using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using PersonalSite.Extensions;
using PersonalSite.Markdown;
using PersonalSite.Services;
using W3.UI;

namespace PersonalSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMarkdownServices();

            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IConfigurationLoader, ConfigurationLoader>();
            services.AddSingleton<IGitHubClient, GitHubClient>();
            services.AddSingleton<Site>();
            services.AddSingleton<IContentParser, ContentParser>();

            services.AddSingleton<Browser>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
