using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Scraper.NBA.BBR.Linker
{
    public class BBRLinkPBPParser : IBBRLinkParser
    {
        private const string _pattern = Regex.Escape("<") + "a href" + Regex.Escape(@"=""/boxscores/pbp/") + @"\d+\w+" + Regex.Escape(@".html"">Play-By-Play");

        public IEnumerable<Link> ParseString(string text)
        {
            var matches = Regex.Matches(text, _pattern);

            return from Match m in matches
                   select new Link(LinkType.PlayByPlay, m.Value);
        }
    }
}
