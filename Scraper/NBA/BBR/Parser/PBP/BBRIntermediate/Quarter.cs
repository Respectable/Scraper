using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public struct Quarter : IBBRPBPInterpretable
    {
        private string _quarter;
        private bool _quarterStart;

        public Quarter(string quarter, bool quarterStart)
        {
            _quarter = quarter;
            _quarterStart = quarterStart;
        }

        public string QuarterInfo
        {
            get { return _quarter; }
        }

        public bool QuarterStart
        {
            get { return _quarterStart; }
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
