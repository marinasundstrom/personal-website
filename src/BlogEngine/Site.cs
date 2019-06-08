using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngine.Configuration;
using BlogEngine.Content;

namespace BlogEngine
{
    public sealed class Site
    {
        private readonly IConfigurationManager configurationManager;
        private readonly ContentManager contentManager;

        public Site(IConfigurationManager configurationManager, ContentManager contentManager)
        {
            this.configurationManager = configurationManager;
            this.contentManager = contentManager;
        }

        public async Task InitializeAsync() 
        {
            await configurationManager.LoadConfigurationAsync();
            await contentManager.LoadContentAsync();
            Posts = contentManager.Posts;
            Pages = contentManager.Pages;
        }

        public string Title { get; set; }

        public string Url { get; set; }

        public IEnumerable<Page> Posts { get; set; }
        public IEnumerable<Page> Pages { get; set; }

        public IDictionary<string, Page> Categories { get; set; }
        public IDictionary<string, Page> Tags { get; set; }

        public IConfiguration Configuration { get; set; }

        public async Task<Page> GetPostAsync(string slug)
        {
            await configurationManager.LoadConfigurationAsync();
            return await contentManager.GetPageAsync(slug);
        }
    }
}
