using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlogEngine.Content.Providers
{
    public class ContentInfo
    {
        public string Dir { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Stream Content { get; set; }
    }
}
