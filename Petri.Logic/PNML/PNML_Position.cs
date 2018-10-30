using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.PNML
{
    class PNML_Position : BindableBase
    {
        [XmlAttribute("X")]
        public bool X
        {
            get { return GetProperty(() => X); }
            set { SetProperty(() => X, value); }
        }

        [XmlAttribute("Y")]
        public bool Y
        {
            get { return GetProperty(() => X); }
            set { SetProperty(() => X, value); }
        }
    }
}
