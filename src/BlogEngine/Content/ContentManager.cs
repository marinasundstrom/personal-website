using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Configuration;
using BlogEngine.Content.Parsers;
using BlogEngine.Content.Providers;

namespace BlogEngine.Content
{
    public class ContentManager
    {
        private readonly IConfigurationManager configuration;
        private readonly IContentProvider contentProvider;
        private readonly PageParser pageParser;

        private List<Page> posts = new List<Page>();
        private List<Page> pages = new List<Page>();

        public ContentManager(
            IConfigurationManager configuration,
            IContentProvider contentProvider,
            PageParser pageParser)
        {
            this.configuration = configuration;
            this.contentProvider = contentProvider;
            this.pageParser = pageParser;
        }

        public async Task LoadContentAsync()
        {
            var contentInfos = await contentProvider.ListContentAsync(ContentType.Post);
            foreach (var contentInfo in contentInfos)
            {
                var page = Posts.FirstOrDefault(x => x.Path.Contains(contentInfo.Path));
                if (page == null)
                {
                    var contentInfo2 = await contentProvider.GetContent(contentInfo.Path);
                    page = await pageParser.ParseAsync(contentInfo2);
                    posts.Add(page);
                }
            }

            posts = posts.OrderByDescending(p => p.Date).ToList();
        }

        public async Task<Page> GetPageAsync(string slug)
        {
            var page = Posts.FirstOrDefault(x => x.Path.Contains(slug));
            if (page == null)
            {
                var contentInfo = await contentProvider.GetContent($"posts/{slug}.md");
                page = await pageParser.ParseAsync(contentInfo);
                posts.Add(page);
            }
            posts = posts.OrderByDescending(p => p.Date).ToList();

            return page;
        }

        public IEnumerable<Page> Posts => posts;
        public IEnumerable<Page> Pages => pages;

        public IDictionary<string, Page> Categories { get; set; }
        public IDictionary<string, Page> Tags { get; set; }
    }
}
