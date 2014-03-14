using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Scraper.NBA.BBR.Linker
{
    public class BBRLinkBoxScoreParser : IBBRLinkParser
    {
        private string _pattern = Regex.Escape(@"/boxscores/") + @"\d+\w+" + Regex.Escape(@".html");
        private const string _linkStart = @"www.basketball-reference.com";

        public IEnumerable<Link> ParseString(string text)
        {
            var matches = Regex.Matches(text, _pattern);

            var dupsRemoved = from Match m in matches
                              group m by m.Value into g
                              select g.First();

            return from Match m in dupsRemoved
                   select new Link(LinkType.PlayByPlay, _linkStart + m.Value);
        }
    }
}
