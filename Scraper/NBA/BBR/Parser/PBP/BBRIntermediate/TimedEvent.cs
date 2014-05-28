using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public class TimedEvent
    {
        public  string Time;
        public  string PBPEvent;

        public TimedEvent()
        {
            Time = "";
            PBPEvent = "";
        }

        public TimedEvent(string time, string pbpEvent)
        {
            Time = time;
            PBPEvent = pbpEvent;
        }

    }
}
