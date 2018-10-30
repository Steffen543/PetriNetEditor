using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.PNML
{
    public class PNML_InitialMarking : BindableBase
    {
        [XmlElement("text")]
        public int Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }

        public PNML_InitialMarking(int value)
        {
            Text = value;
        }

        public PNML_InitialMarking() { }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
