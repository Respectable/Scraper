using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.NBA.BBR.Linker
{
    class BBRLinkAllParser : IBBRLinkParser
    {
        private BBRLinkPBPParser _pbpParser;
        private BBRLinkShotsParser _shotParser;
        private BBRLinkBoxScoreParser _bsParser;

        public IEnumerable<Link> ParseString(string text)
        {
            return _pbpParser.ParseString(text)
                .Concat(_shotParser.ParseString(text))
                .Concat(_bsParser.ParseString(text));
        }
    }
}
