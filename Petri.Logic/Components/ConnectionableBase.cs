using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.PNML;
using Petri.Logic.Xml;

namespace Petri.Logic.Components
{
    public class ConnectableBase : UIPlaceable, IConnectable
    {
        public static double SIZE;

        [XmlElement("name")]
        public PNML_Name Name
        {
            get { return GetProperty(() => Name); }
            set { SetProperty(() => Name, value); }
        }

        [XmlIgnore()]
        public ObservableCollection<Connection> Input { get; set; }

        [XmlIgnore()]
        public ObservableCollection<Connection> Output { get; set; }

        [XmlIgnore()]
        public bool SelectedAsSource
        {
            get { return GetProperty(() => SelectedAsSource); }
            set { SetProperty(() => SelectedAsSource, value); }
        }

        public ConnectableBase()
        {
            Input = new ObservableCollection<Connection>();
            Output = new ObservableCollection<Connection>();
        }

        public ConnectableBase(string id, double x, double y, string name, string description) : base(id, x, y, description)
        {
            Input = new ObservableCollection<Connection>();
            Output = new ObservableCollection<Connection>();
            Name = new PNML_Name(name);
        }
    }
}
