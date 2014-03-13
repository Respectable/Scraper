using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class Link
    {
        private LinkType _type;
        private string _linkPath;

        public string LinkPath
        {
            get { return _linkPath; }
        }

        public LinkType Type
        {
            get { return _type; }
        }

        public Link(LinkType type, string linkPath)
        {
            _type = type;
            _linkPath = linkPath;
        }
    }
}
