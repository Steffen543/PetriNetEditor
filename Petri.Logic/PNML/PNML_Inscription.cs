using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.PNML
{
    public class PNML_Inscription : BindableBase
    {
        [XmlElement("text")]
        public int Text
        {
            get { return GetProperty(() => Text); }
            set { SetProperty(() => Text, value); }
        }

        public PNML_Inscription(int text)
        {
            Text = text;
        }

        public PNML_Inscription() { }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
