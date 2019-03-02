using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class rssList
    {
        private List<rss> list = new List<rss>();

        public List<rss> GetList()
        {
            return list;
        }

        public void addItem(rss item)
        {
            list.Add(item);
        }

        public void fillByRss(ICollection<FeedItem> rssItems, string rssSource)
        {
            foreach (var item in rssItems)
            {
                list.Add(new rss()
                {
                    title = item.Title,
                    date = (DateTime)item.PublishingDate,
                    description = item.Description,
                    link = item.Link,
                    source = rssSource,
                    views = 1
                });
            }
        }
    }
}
