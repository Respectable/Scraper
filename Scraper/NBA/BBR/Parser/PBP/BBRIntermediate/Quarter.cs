using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public struct Quarter : IBBRPBPInterpretable
    {
        private string _quarter;
        private bool _quarterStart;

        public Quarter(string quarter, bool quarterStart)
        {
            _quarter = quarter;
            _quarterStart = quarterStart;
        }

        public string Quarter
        {
            get { return _quarter; }
        }

        public bool QuarterStart
        {
            get { return _quarterStart; }
        }
    }
}
