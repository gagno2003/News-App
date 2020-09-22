using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_App
{
    public class Source
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Article
    {
        public Source source { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishedAt { get; set; }
        public string content { get; set; }
    }

    public class Root
    {
        public string Rname { get; set; }
        public string RurlToImage { get; set; }
        public DateTime RpublishedAt { get; set; }
        public string Rauthor { get; set; }
        public string Rtitle { get; set; }
        public string Rdescription { get; set; }
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
        
    }

}
