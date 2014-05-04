using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using Scraper.NBA.BBR.Parser.PBP.BBRIntermediate;

namespace Scraper.NBA.BBR.Parser.PBP
{
    public class BBRHTMLScraper
    {
        public IEnumerable<string> Scrape(Stream html)
        {
            HtmlDocument doc = new HtmlDocument();
            //TODO: check encoding of html
            doc.Load(html);

            //foreach (HtmlNode node in doc.DocumentNode.Descendants())
            //{
            //    //Console.Out.WriteLine(node.Name + " Line: " + node.Line);
            //    if (node.Name.Equals("table"))
            //    {
            //        foreach (HtmlAttribute att in node.Attributes)
            //        {
            //            Console.Out.WriteLine(att.Value);
            //        }
            //    }
            //}


            HtmlNode pbpNode = (from node in doc.DocumentNode.Descendants("table")
                                where node.Attributes["class"] != null
                                      && node.Attributes["class"].Value != null
                                      && node.Attributes["class"].Value.Equals("no_highlight stats_table")
                                select node)
                                .First();

            foreach (HtmlNode node in pbpNode.Descendants())
            {
                Console.Out.WriteLine(node.Name + " Line: " + node.Line);
            }

            return from tr in pbpNode.Descendants("tr")
                   select ScrapeHelper(tr);
        }

        private string ScrapeHelper(HtmlNode trNode)
        {
            if (trNode.Descendants("th").Count() > 0)
            {
                if (trNode.Descendants("th")
                          .Where(x => x.Attributes.Contains("colspan"))
                          .Count() > 0)
                {
                    return parseQuarterStart(trNode).Interpret();
                }
                else
                {
                    return parseHeader(trNode).Interpret();
                }
            }
            else
            {
                return parseTimedEvent(trNode).Interpret();
            }
        }

        private Quarter parseQuarterStart(HtmlNode trNode)
        {
            string quarterString = trNode.Descendants("th")
                                         .Where(x => x.Attributes.Contains("colspan"))
                                         .First()
                                         .InnerText;
            return new Quarter(quarterString, true);
        }

        private GameHeader parseHeader(HtmlNode trNode)
        {
            var teams = trNode.Descendants("th")
                              .Where(x => !x.Attributes.Contains("colspan") &&
                                          !x.InnerText.Equals("Time"))
                              .Select(x => x.InnerText);
            //TODO make sure home/away always appears this order
            return new GameHeader(teams.Last(), teams.First());
        }

        private TimedEvent parseTimedEvent(HtmlNode trNode)
        {
            string time = trNode.Descendants("td")
                                .First()
                                .InnerText;

            string pbpEvent = trNode.Descendants("td")
                                    .Skip(1)
                                    .Select(n => n.InnerText)
                                    .Aggregate((one, two) => one + two);

            return new TimedEvent(time, pbpEvent);
        }
    }
}
