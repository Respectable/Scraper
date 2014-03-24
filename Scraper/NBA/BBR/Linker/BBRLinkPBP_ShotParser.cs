using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.NBA.BBR.Linker
{
    class BBRLinkPBP_ShotParser : IBBRLinkParser
    {
        private BBRLinkPBPParser _pbpParser;
        private BBRLinkShotsParser _shotParser;

        public BBRLinkPBP_ShotParser()
        {
            _pbpParser = new BBRLinkPBPParser();
            _shotParser = new BBRLinkShotsParser();
        }

        public IEnumerable<Link> ParseString(string text)
        {
            return _pbpParser.ParseString(text).Concat(_shotParser.ParseString(text));
        }
    }
}
