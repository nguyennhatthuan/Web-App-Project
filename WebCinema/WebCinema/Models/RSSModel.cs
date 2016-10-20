using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace WebCinema.Models
{
    public class RSSModel
    {
        public string title { get; set; }

        public string link { get; set; }

        public string description { get; set; }

        public string pubDate { get; set; }
    }
    public class LoadRRSvnexpress
    {
        public string title;
        public string link;
        public string description;
        public string generator;
        public string pubDate;
        public List<RSSModel> items = new List<RSSModel>();

        public LoadRRSvnexpress(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            this.title = channel["title"].InnerText;
            this.link = channel["link"].InnerText;
            this.description = channel["description"].InnerText;
            this.generator = channel["generator"].InnerText;
            this.pubDate = channel["pubDate"].InnerText;

            foreach (XmlNode item in items)
            {
                RSSModel rssItem = new RSSModel();
                rssItem.title = item["title"].InnerText;
                rssItem.description = item["description"].InnerText;
                rssItem.link = item["link"].InnerText;
                rssItem.pubDate = item["pubDate"].InnerText;
                this.items.Add(rssItem);
            }
        }
    }
    public class LoadRRS24h
    {
        public string title;
        public string link;
        public string language;
        public string description;
        public string copyright;
        public string ttl;
        public string generator;
        public List<RSSModel> items = new List<RSSModel>();

        public LoadRRS24h(string url)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(url);

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            this.title = channel["title"].InnerText;
            this.link = channel["link"].InnerText;
            this.description = channel["description"].InnerText;
            this.language = channel["language"].InnerText;
            this.copyright = channel["copyright"].InnerText;
            this.ttl = channel["ttl"].InnerText;
            this.generator = channel["generator"].InnerText;

            foreach (XmlNode item in items)
            {
                RSSModel rssItem = new RSSModel();
                rssItem.title = item["title"].InnerText;
                rssItem.description = item["description"].InnerText;
                rssItem.link = item["link"].InnerText;
                rssItem.pubDate = item["pubDate"].InnerText;
                this.items.Add(rssItem);
            }
        }
    }
}