using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.NBA.BBR.Linker
{
    public class BBRLinkBoxScore_ShotParser : IBBRLinkParser
    {
        private BBRLinkBoxScoreParser _bsParser;
        private BBRLinkShotsParser _shotParser;

        public IEnumerable<Link> ParseString(string text)
        {
            return _bsParser.ParseString(text).Concat(_shotParser.ParseString(text));
        }
    }
}
