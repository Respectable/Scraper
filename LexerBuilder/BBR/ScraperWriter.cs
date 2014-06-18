using Scraper.NBA.BBR.Parser.PBP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexerBuilder.BBR
{
    public class ScraperWriter
    {
        private const string inputPath = @"D:\Anthony\Dropbox\NBA Final\BBR PBP\2013-2014\";
        private const string outputPath = @"D:\Anthony\Documents\Research\New Raw Data\2013-2014 Regular Season\";

        public void write()
        {
            IEnumerable<string> filePaths = Directory.GetFiles(inputPath);

            foreach (string pth in filePaths)
            {
                int namePartStartIndex = pth.LastIndexOf('\\') + 1;
                int namePartEndIndex = pth.IndexOf('.');
                string fileNamePart = pth.Substring(namePartStartIndex, (namePartEndIndex - namePartStartIndex));

                using (System.IO.FileStream file = System.IO.File.Open(pth, System.IO.FileMode.Open))
                {
                    using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(outputPath + fileNamePart + ".pbp"))
                    {
                        var scraper = new BBRHTMLScraper();
                        outFile.Write(scraper.Scrape(file).Aggregate((x, y) => x + "\n" + y));
                    }
                }
            }
        }
    }
}
