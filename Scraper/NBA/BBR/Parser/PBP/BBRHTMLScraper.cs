using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;

namespace Scraper.NBA.BBR.Parser.PBP
{
    class BBRHTMLScraper
    {
        public IEnumerable<string> Scrape(Stream html)
        {
            HtmlDocument doc = new HtmlDocument();
            //TODO: check encoding of html
            doc.Load(html);

            HtmlNode pbpNode = doc.DocumentNode.Descendants("table")
                                               .Where(x => x.Attributes["class"].Value == "no_highlight stats_table")
                                               .First();

            return from tr in pbpNode.Descendants("tr")
                   select ScrapeHelper(tr);
        }

        private string ScrapeHelper(HtmlNode trNode)
        {
            ret
        }
    }
}
