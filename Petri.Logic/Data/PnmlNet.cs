using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;
using Petri.Logic.Helper;

namespace Petri.Logic.Data
{
    [XmlRoot("pnml", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class PnmlNet : BindableBase
    {
        [XmlElement("net")]
        public Net PetriNet
        {
            get { return GetProperty(() => PetriNet); }
            set { SetProperty(() => PetriNet, value); }
        }

        public PnmlNet()
        {
            PetriNet = new Net();
            ArrowManagement.ObjectList = PetriNet.Objects;
        }


    }
}
