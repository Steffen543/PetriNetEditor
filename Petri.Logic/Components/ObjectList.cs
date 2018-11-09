using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Logic.Components
{
    public class ObjectList : ObservableCollection<UIPlaceable>
    {
        public new void Add(UIPlaceable item)
        {
            if (item is Connection conn)
                Insert(0, conn);
            else
            base.Add(item);
            
        }

        public ObservableCollection<ConnectableBase> GetConnectables()
        {
            var list = new ObservableCollection<ConnectableBase>();
            foreach (var obj in this)
            {
                if (obj is Transition trans)
                    list.Add(trans);
                if (obj is Place stelle)
                    list.Add(stelle);
            }
            return list;
        }

        public ObservableCollection<Connection> GetAllConnectionsBetween2Connectables(ConnectableBase component1,
            ConnectableBase component2)
        {
            var connections = GetConnections().Where(c =>
                (c.Source == component1 || c.Source == component2) &&
                (c.Destination == component2 || c.Destination == component1));
            return new ObservableCollection<Connection>(connections);
        }

        public ObservableCollection<Transition> GetTransitions()
        {
            var list = new ObservableCollection<Transition>();
            foreach (var obj in this)
            {
                if (obj is Transition trans)
                    list.Add(trans);
               
            }
            return list;
        }


        public ObservableCollection<Connection> GetConnections()
        {
            var list = new ObservableCollection<Connection>();
            foreach (var obj in this)
            {
                if (obj is Connection conn)
                    list.Add(conn);
            }
            return list;
        }

       

    }
}
