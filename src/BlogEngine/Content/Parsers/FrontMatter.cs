using System;
using System.Collections.Generic;

namespace BlogEngine.Content.Parsers
{
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

        // Additional
        public string Image { get; set; }

        public string Author { get; set; }
    }
}
