using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public struct Quarter
    {
        public string QuarterInfo;
        public bool QuarterStart;

        public Quarter(string quarter, bool quarterStart)
        {
            QuarterInfo = quarter;
            QuarterStart = quarterStart;
        }

    }
}
