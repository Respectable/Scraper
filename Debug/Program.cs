using Scraper.NBA.BBR.Parser.PBP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"D:\Anthony\Dropbox\NBA Final\BBR PBP\2013-2014\201310290IND.html";

            using (System.IO.FileStream file = System.IO.File.Open(path, System.IO.FileMode.Open))
            {
                var scraper = new BBRHTMLScraper();
                Console.Out.Write(scraper.Scrape(file).Aggregate((x, y) => x + "\n" + y));
            }
        }
    }
}
