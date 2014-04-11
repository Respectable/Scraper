using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public struct GameHeader : IBBRPBPInterpretable
    {
        private string _home, _away;

        public GameHeader(string home, string away)
        {
            _home = home;
            _away = away;
        }

        public string Home
        {
            get { return _home; }
        }

        public string Away
        {
            get { return _away; }
        }
    }
}
