using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using Scraper.NBA.BBR.Parser.PBP.BBRIntermediate;
using System.Xml;
using System.Xml.Serialization;

namespace Scraper.NBA.BBR.Parser.PBP
{
    public class BBRHTMLScraper
    {
        public IEnumerable<string> Scrape(Stream html)
        {
            HtmlDocument doc = new HtmlDocument();
            //TODO: check encoding of html
            doc.Load(html);

            //get table node containing all the tr nodes containing pbp data
            HtmlNode pbpNode = (from node in doc.DocumentNode.Descendants("table")
                                where node.Attributes["class"] != null
                                      && node.Attributes["class"].Value != null
                                      && node.Attributes["class"].Value.Equals("no_highlight stats_table")
                                select node)
                                .First();

            //annotate all the players appear in 'a' nodes in pbp data
            List<HtmlNode> trNodes = pbpNode.Descendants("tr").ToList();
            for (int i = trNodes.Count() - 1; i >= 0; i--)
            {
                List<HtmlNode> aNodes = trNodes[i].Descendants("a").ToList();
                for (int j = aNodes.Count() - 1; j >= 0; j--)
                {
                    if (aNodes[j].Attributes.Contains("href"))
                    {
                        AddPlayerURL(aNodes[j], aNodes[j].InnerText);
                    }
                }
            }

            //get parsed xml from pbp data
            return from tr in pbpNode.Descendants("tr")
                   select ScrapeHelper(tr);
        }

        private string ScrapeHelper(HtmlNode trNode)
        {
            if (trNode.Descendants("th").Count() > 0)
            {
                if (trNode.Descendants("th")
                          .Where(x => x.Attributes.Contains("colspan"))
                          .Count() > 0
                    && trNode.Descendants("th").Count() < 3)
                {
                    return Interpret(ParseQuarterStart(trNode));
                }
                else
                {
                    return Interpret(ParseHeader(trNode));
                }
            }
            else
            {
                return Interpret(ParseTimedEvent(trNode));
            }
        }

        private Quarter ParseQuarterStart(HtmlNode trNode)
        {
            string quarterString = trNode.Descendants("th")
                                         .Where(x => x.Attributes.Contains("colspan"))
                                         .First()
                                         .InnerText.Replace('\n', ' ');

            quarterString = CondenseWhitespace(quarterString);

            return new Quarter(quarterString, true);
        }

        private GameHeader ParseHeader(HtmlNode trNode)
        {
            var teams = trNode.Descendants("th")
                              .Where(x => !x.Attributes.Contains("colspan") &&
                                          !x.InnerText.Equals("Time"))
                              .Select(x => x.InnerText);
            //TODO make sure home/away always appears this order
            return new GameHeader(teams.Last(), teams.First());
        }

        private TimedEvent ParseTimedEvent(HtmlNode trNode)
        {
            string time = trNode.Descendants("td")
                                .First()
                                .InnerText;

            string pbpEvent = trNode.Descendants("td")
                                    .Skip(1)
                                    .Select(n => n.InnerText.Replace('\n', ' '))
                                    .Aggregate((one, two) => one + " " + two);

            pbpEvent = CondenseWhitespace(pbpEvent);

            return new TimedEvent(time, pbpEvent);
        }

        private void AddPlayerURL(HtmlNode aNode, string url)
        {
            string newText = "[{" + aNode.Attributes["href"].Value + "} " + aNode.InnerText + "]";
            aNode.ParentNode.ReplaceChild(HtmlNode.CreateNode(newText), aNode);
        }

        private string CondenseWhitespace(string strToCondense)
        {

            strToCondense = strToCondense.Replace('Â', ' ');
            return System.Text.RegularExpressions.Regex.Replace(strToCondense, @"\s+", " ");
        }

        private string Interpret(Object o)
        {
            string retval = "";
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o, ns);
            }
            retval = sb.ToString();
            return retval;
        }
    }
}
