using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public class TimedEvent : IBBRPBPInterpretable
    {

        private string _time;
        private string _pbpEvent;

        public TimedEvent(string time, string pbpEvent)
        {
            _time = time;
            _pbpEvent = pbpEvent;
        }

        public string Time
        {
            get { return _time; }
        }

        public string PBPEvent
        {
            get { return _pbpEvent; }
        }

        public string Interpret()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }
}
