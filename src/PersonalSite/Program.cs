using Microsoft.AspNetCore.Blazor.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BlogEngine;
using PersonalSite.Extensions;
using PersonalSite.Markdown;

namespace PersonalSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = WebAssemblyHostBuilder.CreateDefault();
            hostBuilder.RootComponents.Add<App>("app");

            hostBuilder.Services.AddBlogSite(options => 
                options.AddGitHubProvider());
                
            hostBuilder.Services.AddMarkdownServices();

            hostBuilder.Services.AddSingleton<Browser>();

            var host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}
