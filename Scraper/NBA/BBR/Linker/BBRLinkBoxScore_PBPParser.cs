using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Scraper.NBA.BBR.Linker
{
    public class BBRLinkBoxScore_PBPParser : IBBRLinkParser
    {
        private BBRLinkBoxScoreParser _bsParser;
        private BBRLinkPBPParser _pbpParser;

        public IEnumerable<Link> ParseString(string text)
        {
            return _bsParser.ParseString(text).Concat(_pbpParser.ParseString(text));
        }
    }
}
