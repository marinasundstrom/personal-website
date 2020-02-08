using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PersonalSite.Components
{
    public sealed class DisqusService
    {
        private readonly IJSRuntime jSRuntime;
        private readonly DisqusConfig config;
        private readonly NavigationManager navigationManager;

        public DisqusService(IJSRuntime jSRuntime, DisqusConfig config, NavigationManager navigationManager)
        {
            this.jSRuntime = jSRuntime;
            this.config = config;
            this.navigationManager = navigationManager;
        }

        public async Task InitThreadAsync()
        {
            var c = new DisqusConfig2
            {
                site = config.Site,
                page = new PageConfig
                {
                    url = navigationManager.Uri,
                    identifier = navigationManager.ToBaseRelativePath(navigationManager.Uri)
                }
            };
            await jSRuntime.InvokeVoidAsync("disqus.initThread", c);
        }

        public async Task InitCountAsync(string url)
        {
            var c = new DisqusConfig2
            {
                site = config.Site,
                page = new PageConfig
                {
                    url = url,
                    identifier = new Uri(url).AbsolutePath
                }
            };
            await jSRuntime.InvokeVoidAsync("disqus.initCount", c);
        }
    }

    public class DisqusConfig 
    {
        public string Site { get; set; }
    }

    class DisqusConfig2
    {
        public string site { get; set; }

        public PageConfig page { get; set; }
    }

    class PageConfig 
    {
        public string url { get; set; }

        public string identifier { get; set; }
    }
}
