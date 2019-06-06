using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalSite.Services
{
    public sealed class ContentPage
    {
        private IEnumerable<string> tags;

        public string Title => GetAttributeOrDefault("title");

        public string Author => GetAttributeOrDefault("author");

        public DateTime Date => DateTime.Parse(GetAttributeOrDefault("date"));

        public string Excerpt => GetAttributeOrDefault("excerpt");

        public string Image => GetAttributeOrDefault("image");

        public IEnumerable<string> Tags => (tags = GetAttributeOrDefault("tags")?
            .Split(',')?
            .Select(tag => tag.Trim()));

        public string Content { get; set; }

        public IReadOnlyDictionary<string, string> Attributes { get; set; }
        public string Slug { get; internal set; }

        private string GetAttributeOrDefault(string key)
        {
            Attributes.TryGetValue(key, out string result);
            return result;
        }
    }
}
