using BlogEngine;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using PersonalSite.Extensions;
using PersonalSite.Markdown;
using W3.UI;

namespace PersonalSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlogSite(options => 
                options.AddGitHubProvider());
                
            services.AddMarkdownServices();

            services.AddSingleton<Browser>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
