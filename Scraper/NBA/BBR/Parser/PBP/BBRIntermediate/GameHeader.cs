using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public struct GameHeader
    {
        public string Home, Away;

        public GameHeader(string home, string away)
        {
            Home = home;
            Away = away;
        }
    }
}
