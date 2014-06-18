using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using Scraper.NBA.BBR.Parser.PBP;

namespace ScraperTest.BBR.Parser
{
    [TestFixture]
    public class BBRHTMLScraperTest
    {

        [Test]
        [Ignore("files were cleaned & downloaded to desktop")]
        public void ReadFromWebsite()
        {
            WebRequest http = null;
            WebResponse response = null;
            System.IO.Stream stream = null;
            
            try
            {
                http = WebRequest.Create("http://www.basketball-reference.com/boxscores/pbp/201404140ATL.html");
                response = http.GetResponse();
                stream = response.GetResponseStream();
                var scraper = new BBRHTMLScraper();
                Console.Out.Write(scraper.Scrape(stream).Aggregate((x,y) => x + "\n" + y));
                
            }
            finally
            {
                stream.Close();
                response.Close();
                http = null;
            }
            
        }

        [Test]
        public void ReadFromFile()
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
