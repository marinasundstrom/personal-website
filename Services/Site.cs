using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PersonalSite.Services
{
    public class Site
    {
        private readonly IGitHubClient gitHubClient;
        private readonly IContentParser contentParser;

        public Site(
            IGitHubClient gitHubClient,
            IContentParser contentParser)
        {
            this.gitHubClient = gitHubClient;
            this.contentParser = contentParser;
        }

        public List<ContentPage> Posts { get; set; } = new List<ContentPage>();

        public async Task LoadContentAsync()
        {
            var content = await gitHubClient.GetContentAsync("posts");
            foreach (var file in content)
            {
                if (file.path.Contains("README"))
                {
                    continue;
                }

                await GetPostAsync(file.name.Replace(".md", ""), false);
            }

            Posts = Posts.OrderByDescending(p => p.Date).ToList();
        }

        public async Task<ContentPage> GetPostAsync(string slug, bool sort = true)
        {
            var post = Posts.FirstOrDefault(x => x.Slug == slug);
            if (post == null)
            {
                var fileContent = await gitHubClient.GetRawContentAsync($"posts/{slug}.md");
                post = contentParser.ParseContent(fileContent, slug);
                Posts.Add(post);
                if (sort)
                {
                    Posts = Posts.OrderByDescending(p => p.Date).ToList();
                }
            }
            return post;
        }
    }
}
