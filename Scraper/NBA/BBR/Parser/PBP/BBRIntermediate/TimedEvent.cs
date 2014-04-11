using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public class TimedEvent : IBBRPBPInterpretable
    {
        private string _time;
        private PBPEvent _pbpEvent;

        public TimedEvent(string time, PBPEvent pbpEvent)
        {
            _time = time;
            _pbpEvent = pbpEvent;
        }

        public string Time
        {
            get { return _time; }
        }

        public PBPEvent PBPEvent
        {
            get { return _pbpEvent; }
        }
    }
}
