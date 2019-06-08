using System;
using System.Collections.Generic;

namespace BlogEngine.Content
{
    public class Page
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Id { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Dir { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public string Image { get; set; }
    }
}
