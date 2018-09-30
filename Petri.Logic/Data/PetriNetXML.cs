using Petri.Logic.Components;
using Petri.Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Petri.Logic.Data
{
    [XmlRoot("PetriNetXML", Namespace = "http://www.cpandl.com", IsNullable = false)]
    public class PetriNetXML
    {
        [XmlArray("TransitionsArray")]
        [XmlArrayItem("Transition")]
        public ObservableCollection<Transition> Transitions;
        [XmlArray("StellenArray")]
        [XmlArrayItem("Stellen")]
        public ObservableCollection<Stelle> Stellen;
        [XmlArray("ConnectionsArray")]
        [XmlArrayItem("Connections")]
        public ObservableCollection<Connection> Connections;

        public PetriNetXML()
        {
            Transitions = new ObservableCollection<Transition>();
            Stellen = new ObservableCollection<Stelle>();
            Connections = new ObservableCollection<Connection>();
        }

        public void AddTestEntries()
        {

            Transitions.Add(new Transition(0, 100, 100, "Main", "Beschreibung"));
            Transitions.Add(new Transition(1, 600, 100, "Test", "Beschreibung"));
            Transitions.Add(new Transition(2, 100, 600, "Hallo", "Beschreibung"));

            Stellen.Add(new Stelle(3, 300, 100, "Stelle 1", "Stelllenbeschreibung", 9, 0));
            Stellen.Add(new Stelle(4, 100, 300, "Stelle 2", "Stelllenbeschreibung", 12, 0));
            Stellen.Add(new Stelle(5, 600, 600, "Stelle 3", "Stelllenbeschreibung", 7, 0));

            Connections.Add(new Connection(6, 0, 3, 3, "Conn1", "Connbeschreibung"));
            Connections.Add(new Connection(7, 3, 1, 6, "Conn2", "Connbeschreibung"));
            Connections.Add(new Connection(8, 0, 4, 8, "Conn3", "Connbeschreibung"));
            Connections.Add(new Connection(9, 4, 0, 1, "Conn4", "Connbeschreibung"));
            Connections.Add(new Connection(10, 1, 5, 7, "Conn5", "Connbeschreibung"));
            Connections.Add(new Connection(11, 5, 1, 3, "Conn6", "Connbeschreibung"));
            Connections.Add(new Connection(12, 0, 5, 2, "Conn7", "Connbeschreibung"));
            Connections.Add(new Connection(13, 2, 4, 2, "Conn8", "Connbeschreibung"));

            Stellen[1].Value = 1;

            //Connections.Add(new Connection(Stellen[1], Transitions[2], 2, 4));

        }

        public void InitDependencies()
        {
            foreach(var obj in Transitions)
            {
                InitDependency(obj);
            }
            foreach (var obj in Stellen)
            {
                InitDependency(obj);
            }
            foreach (var obj in Connections)
            {
                InitDependency(obj);
            }
        }

        public void InitDependency(ConnectableBase obj)
        {
            var destinations = Connections.Where(c => c.SourceId == obj.Id);
            var sources = Connections.Where(c => c.DestinationId == obj.Id);

            obj.Input = new ObservableCollection<Connection>(sources);
            obj.Output = new ObservableCollection<Connection>(destinations);

        }

        public void InitDependency(Connection connection)
        {
            var list = GetAllInList();
            connection.Source = GetAllInList().Where(o => o.Id == connection.SourceId).First() as IConnectable;
            connection.Destination = GetAllInList().Where(o => o.Id == connection.DestinationId).First() as IConnectable;
            connection.X = connection.Source.X;
            connection.Y = connection.Source.Y;
        }

      
     

        public EditorViewModel GetEditorViewModel()
        {
            EditorViewModel model = new EditorViewModel();
            model.petriNetXML = this;
            model.Items = GetAllInList();
            return model;
        }

        public ObservableCollection<UIPlaceable> GetAllInList()
        {
            ObservableCollection<UIPlaceable> reuturnValue = new ObservableCollection<UIPlaceable>();
            foreach (var connection in Connections) reuturnValue.Add(connection);
            foreach (var transition in Transitions) reuturnValue.Add(transition);
            foreach (var stelle in Stellen) reuturnValue.Add(stelle);
            return reuturnValue;
        }

        public int CreateId()
        {
            return GetAllInList().Select(i => i.Id).Max() + 1;
        }
    }
}
