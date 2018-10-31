using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.Pnml
{
    public class Name : BindableBase
    {
        [XmlElement("text")]
        public string Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }

        public Name(string text)
        {
            Text = text;
        }

        public Name()  { }

        public override string ToString()
        {
            return Text;
        }
    }
}
