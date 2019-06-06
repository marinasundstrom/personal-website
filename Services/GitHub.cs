using System;
using System.Collections;
using System.Linq;

namespace PersonalSite.Services
{


    public class Content
    {
        public string type { get; set; }
        public string encoding { get; set; }
        public int size { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string content { get; set; }
        public string sha { get; set; }
        public string url { get; set; }
        public string git_url { get; set; }
        public string html_url { get; set; }
        public string download_url { get; set; }
        public _Links _links { get; set; }
    }

    public class _Links
    {
        public string git { get; set; }
        public string self { get; set; }
        public string html { get; set; }
    }

}
