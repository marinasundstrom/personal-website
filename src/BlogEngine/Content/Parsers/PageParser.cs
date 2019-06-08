using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BlogEngine.Content.Providers;

namespace BlogEngine.Content.Parsers
{
    public class PageParser
    {
        private readonly FrontMatterParser frontMatterParser;

        public PageParser(FrontMatterParser FrontMatterParser) 
        {
            frontMatterParser = FrontMatterParser;
        }

        public async Task<Page> ParseAsync(ContentInfo contentInfo)
        {
            using (StreamReader streamReader = new StreamReader(contentInfo.Content))
            {   
                string content = null;
                FrontMatter frontMatter = null;
                
                content = await streamReader.ReadToEndAsync();

                MatchCollection matches = Regex.Matches(content, "^---+$", RegexOptions.Multiline);

                if (matches.Count >= 2)
                {
                    Match first = matches[0];
                    Match second = matches[1];

                    if (first.Captures[0].Index == 0)
                    {
                        string frontMatterString = content.Substring(first.Captures[0].Index + first.Captures[0].Length, second.Captures[0].Index - first.Captures[0].Length);
                        frontMatter = frontMatterParser.Parse(frontMatterString);
                    }
                    content = content.Substring(second.Captures[0].Index + second.Captures[0].Length);
                }

                return BuildPage(contentInfo, content, frontMatter);
            }
        }

        private Page BuildPage(ContentInfo contentInfo, string content, FrontMatter frontMatter)
        {
            var page = new Page();
            if(frontMatter != null) 
            {
                page.Id = Path.GetFileNameWithoutExtension(contentInfo.Path);
                page.Title = frontMatter.Title;
                page.Date = frontMatter.Date;

                page.Content = content;
                page.Name = contentInfo.Name;
                page.Path = contentInfo.Path;
                page.Dir = contentInfo.Dir;

                page.Content = content;
            }
            return page;
        }
    }
}
