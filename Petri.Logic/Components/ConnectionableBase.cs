using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Petri.Logic.Components
{
    public class ConnectableBase : UIPlaceable, IConnectable
    {
        [XmlIgnore()]
        public ObservableCollection<Connection> Input { get; set; }

        [XmlIgnore()]
        public ObservableCollection<Connection> Output { get; set; }

        public ConnectableBase()
        {
            Input = new ObservableCollection<Connection>();
            Output = new ObservableCollection<Connection>();
        }

        public ConnectableBase(int id, double x, double y, string name, string description) : base(id, x, y, description, name)
        {
            Input = new ObservableCollection<Connection>();
            Output = new ObservableCollection<Connection>();
        }
    }
}
