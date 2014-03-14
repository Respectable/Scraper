using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Scraper.NBA.BBR.Linker
{
    public class BBRLinkShotsParser : IBBRLinkParser
    {
        private string _pattern = Regex.Escape(@"/shot-chart/") + @"\d+\w+" + Regex.Escape(@".html");
        private const string _linkStart = @"www.basketball-reference.com/boxscores";

        public IEnumerable<Link> ParseString(string text)
        {
            var matches = Regex.Matches(text, _pattern);

            return from Match m in matches
                   select new Link(LinkType.PlayByPlay, _linkStart + m.Value);
        }
    }
}
