using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace PersonalSite.Services
{
    public sealed class ContentParser : IContentParser
    {
        public ContentPage ParseContent(string content, string slug = null)
        {
            MatchCollection matches = Regex.Matches(content, "^---+$", RegexOptions.Multiline);

            FrontMatter frontMatter = null;

            if (matches.Count >= 2)
            {
                Match first = matches[0];
                Match second = matches[1];

                if (first.Captures[0].Index == 0)
                {
                    string info = content.Substring(first.Captures[0].Index + first.Captures[0].Length, second.Captures[0].Index - first.Captures[0].Length);

                    var input = new StringReader(info);

                    var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(new CamelCaseNamingConvention())
                        .Build();

                    frontMatter = deserializer.Deserialize<FrontMatter>(input);

                }
                content = content.Substring(second.Captures[0].Index + second.Captures[0].Length);
            }

            frontMatter.Slug = slug;

            return new ContentPage
            {
                FrontMatter = frontMatter,
                Content = content
            };
        }
    }

    public class FrontMatter
    {
        public string Layout { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public bool Published { get; set; }

        public DateTime Date { get; set; }      
        public string Category { get; set; }   
        public List<string> Categories { get; set; }
        public List<string> Tags { get; set; }

        public string Author { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
    }
}
