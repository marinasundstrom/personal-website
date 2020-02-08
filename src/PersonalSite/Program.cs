using Microsoft.AspNetCore.Blazor.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BlogEngine;
using PersonalSite.Extensions;
using PersonalSite.Markdown;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using BlogEngine.Configuration;
using PersonalSite.Components;

namespace PersonalSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = WebAssemblyHostBuilder.CreateDefault();
            hostBuilder.RootComponents.Add<App>("app");

            hostBuilder.Services.AddHeadElementHelper();
            hostBuilder.Services.AddLoadingBar();

            hostBuilder.Services.AddBlogSite(options => 
                options.AddGitHubProvider());
                
            hostBuilder.Services.AddMarkdownServices();

            hostBuilder.Services.AddSingleton<DisqusConfig>(sp => new DisqusConfig() {
                Site = "robert-sundstrom"
            });

            hostBuilder.Services.AddSingleton<DisqusService>();

            hostBuilder.Services.AddSingleton<Browser>();

            var host = hostBuilder
                .Build()
                .UseLoadingBar();

            var configurationManager = host.Services.GetService<IConfigurationManager>();

            await configurationManager.LoadConfigurationAsync();

            await host.RunAsync();
        }
    }
}
