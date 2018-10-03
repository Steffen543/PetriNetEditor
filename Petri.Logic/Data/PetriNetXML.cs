using Petri.Logic.Components;
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
        [XmlArray("Objects")]
        [XmlArrayItem("Transition", Type=typeof(Transition))]
        [XmlArrayItem("Connection", Type = typeof(Connection))]
        [XmlArrayItem("Stelle", Type = typeof(Stelle))]
        public ObjectList Objects { get; set; }


        public PetriNetXML()
        {
            Objects = new ObjectList();
        }

        public void AddTestEntries()
        {

            Objects.Add(new Transition(0, 100, 100, "Main", "Beschreibung"));
            Objects.Add(new Transition(1, 600, 100, "Test", "Beschreibung"));
            Objects.Add(new Transition(2, 100, 600, "Hallo", "Beschreibung"));

            Objects.Add(new Stelle(3, 300, 100, "Stelle 1", "Stelllenbeschreibung", 0));
            Objects.Add(new Stelle(4, 100, 300, "Stelle 2", "Stelllenbeschreibung", 0));
            Objects.Add(new Stelle(5, 600, 600, "Stelle 3", "Stelllenbeschreibung", 0));

            Objects.Add(new Connection(6, 0, 3, 3, "Conn1", "Connbeschreibung"));
            Objects.Add(new Connection(7, 3, 1, 6, "Conn2", "Connbeschreibung"));
            Objects.Add(new Connection(8, 0, 4, 8, "Conn3", "Connbeschreibung"));
            Objects.Add(new Connection(9, 4, 0, 1, "Conn4", "Connbeschreibung"));
            Objects.Add(new Connection(10, 1, 5, 7, "Conn5", "Connbeschreibung"));
            Objects.Add(new Connection(11, 5, 1, 3, "Conn6", "Connbeschreibung"));
            Objects.Add(new Connection(12, 0, 5, 2, "Conn7", "Connbeschreibung"));
            Objects.Add(new Connection(13, 2, 4, 2, "Conn8", "Connbeschreibung"));

            //Stellen[1].Value = 1;

            //Connections.Add(new Connection(Stellen[1], Transitions[2], 2, 4));

        }

        public void InitDependencies()
        {
            foreach(var obj in Objects.GetConnectables())
            {
                InitDependency(obj);
            }
           
            foreach (var obj in Objects.GetConnections())
            {
                InitDependency(obj);
            }

            foreach (var obj in Objects.GetTransitions())
            {
                obj.CalcIsExecutable();
            }

            foreach (var obj in Objects.GetConnections())
            {
                obj.CalcIsExecutable();
            }
        }

        public void InitDependency(ConnectableBase obj)
        {
            var destinations = Objects.GetConnections().Where(c => c.SourceId == obj.Id);
            var sources = Objects.GetConnections().Where(c => c.DestinationId == obj.Id);

            obj.Input = new ObservableCollection<Connection>(sources);
            obj.Output = new ObservableCollection<Connection>(destinations);

           

        }

        public void InitDependency(Connection connection)
        {
            connection.Source = Objects.Where(o => o.Id == connection.SourceId).First() as IConnectable;
            connection.Destination = Objects.Where(o => o.Id == connection.DestinationId).First() as IConnectable;
            connection.X = connection.Source.X;
            connection.Y = connection.Source.Y;
        }

      
     

      

       

        public int CreateId()
        {
            if (Objects.Count == 0) return 0;
            return Objects.Select(i => i.Id).Max() + 1;
        }
    }
}
