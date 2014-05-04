using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraper.NBA.BBR.Linker;

namespace BBRLinkGenerator
{
    class BBRLinkGatherer
    {
        static void Main(string[] args)
        {
            DateTime startDate, endDate;

            startDate = new DateTime(2013, 10, 29);
            endDate = new DateTime(2014, 4, 16);

            BBRLinkPBPParser parser = new BBRLinkPBPParser();

            BBRLinker linker = new BBRLinker(startDate, endDate, parser);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Anthony\Desktop\links.txt"))
            {
                linker.GetLinks().ToList().ForEach(x => file.WriteLine(x.LinkPath));
            }
        }
    }
}
