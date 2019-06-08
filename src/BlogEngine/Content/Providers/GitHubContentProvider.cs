using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Configuration;

namespace BlogEngine.Content.Providers
{
    public class GitHubContentProvider : IContentProvider
    {
        private readonly IConfigurationManager configuration;
        private readonly IGitHubClient gitHubClient;

        public GitHubContentProvider(IConfigurationManager configuration, IGitHubClient gitHubClient)
        {
            this.configuration = configuration;
            this.gitHubClient = gitHubClient;
        }

        public async Task<ContentInfo> GetContent(string path)
        {
            var content = await gitHubClient.GetRawContentAsync(path);
            return new ContentInfo()
            {
                Name = Path.GetFileName(path),
                Path = path,
                Dir = Path.GetDirectoryName(path),
                Content = new MemoryStream(Encoding.UTF8.GetBytes(content))
            };
        }

        public async Task<Stream> GetRawContent(string path)
        {
              var content = await gitHubClient.GetRawContentAsync(path);
              return new MemoryStream(Encoding.UTF8.GetBytes(content));
        }

        public async Task<IEnumerable<ContentInfo>> ListContentAsync(ContentType contentType)
        {
            var dirPath = "/posts";
            var content = await gitHubClient.GetContentAsync(dirPath);
            return content.Select(c => new ContentInfo()
            {
                Name = c.name,
                Path = c.path,
                Dir = Path.GetDirectoryName(c.path)
            });
        }
    }
}
