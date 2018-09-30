using Petri.Logic.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Petri.Logic.Xml
{
    public class PetriNetXMLReader
    {
        public void SaveToXML(PetriNetXML petriNet, string fileName)
        {
            System.Xml.Serialization.XmlSerializer writer =
           new System.Xml.Serialization.XmlSerializer(typeof(PetriNetXML));

               System.IO.FileStream file = System.IO.File.Create(fileName);

            writer.Serialize(file, petriNet);
            file.Close();
        }

        public PetriNetXML ReadFromXML(string fileName)
        {
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
           
            XmlSerializer deserializer = new XmlSerializer(typeof(PetriNetXML));
            return (PetriNetXML)deserializer.Deserialize(fileStream);
           



            System.Xml.Serialization.XmlSerializer writer =
           new System.Xml.Serialization.XmlSerializer(typeof(PetriNetXML));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this);
            file.Close();
        }
    }
}
