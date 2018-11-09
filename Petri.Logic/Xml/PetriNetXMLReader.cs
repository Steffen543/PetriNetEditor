using Petri.Logic.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Helper;

namespace Petri.Logic.Xml
{
    public class PetriNetXMLReader
    {
        public void SaveToXML(PnmlNet pnmlNet, string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(PnmlNet));
            FileStream file = File.Create(fileName);
            writer.Serialize(file, pnmlNet);
            file.Close();
        }

        public PnmlNet ReadFromXML(string fileName)
        {
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer deserializer = new XmlSerializer(typeof(PnmlNet));
            var net =  (PnmlNet)deserializer.Deserialize(fileStream);
            fileStream.Close();
            return net;
        }
    }
}
