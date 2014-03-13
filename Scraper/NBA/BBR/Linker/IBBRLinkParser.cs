using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.NBA.BBR.Linker
{
    public interface IBBRLinkParser
    {
        IEnumerable<Link> ParseString(string text);
    }
}
