using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.Pnml
{
    public class PlaceInitialMarking : BindableBase
    {
        [XmlElement("text")]
        public int Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }

        public PlaceInitialMarking(int value)
        {
            Text = value;
        }

        public PlaceInitialMarking() { }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
