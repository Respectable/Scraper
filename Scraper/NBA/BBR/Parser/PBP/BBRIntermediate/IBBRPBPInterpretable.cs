using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Scraper.NBA.BBR.Parser.PBP.BBRIntermediate
{
    public interface IBBRPBPInterpretable
    {
        public string Interpret()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();

            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }
}
