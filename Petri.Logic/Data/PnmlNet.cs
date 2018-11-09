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
    [XmlRoot("pnml", Namespace = "http://www.pnml.org/version-2009/grammar/pnml", IsNullable = false)]
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
           
        }

        public void InitArrowManagement()
        {
            ArrowManagement.Clear();
            ArrowManagement.ObjectList = PetriNet.Objects;
        }


    }
}
