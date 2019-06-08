using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlogEngine.Content.Providers
{
    public interface IContentProvider
    {
        Task<IEnumerable<ContentInfo>> ListContentAsync(ContentType contentType);
        Task<ContentInfo> GetContent(string path);
        Task<Stream> GetRawContent(string path);
    }
}
