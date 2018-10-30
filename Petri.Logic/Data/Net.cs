using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Components;
using Petri.Logic.PNML;

namespace Petri.Logic.Data
{
    public class Net
    {
        public PNML_Name name { get; set; }

        [XmlArray("page")]
        [XmlArrayItem("transition", Type = typeof(Transition))]
        [XmlArrayItem("arc", Type = typeof(Connection))]
        [XmlArrayItem("place", Type = typeof(Place))]
        public ObjectList Objects { get; set; }

        public Net()
        {
            Objects = new ObjectList();
        }

        public void AddTestEntries()
        {

            Objects.Add(new Transition("0", 100, 100, "Main", "Beschreibung"));
            Objects.Add(new Transition("1", 600, 100, "Test", "Beschreibung"));
            Objects.Add(new Transition("2", 100, 600, "Hallo", "Beschreibung"));

            Objects.Add(new Place("3", 300, 100, "Place 1", "Stelllenbeschreibung", 0));
            Objects.Add(new Place("4", 100, 300, "Place 2", "Stelllenbeschreibung", 0));
            Objects.Add(new Place("5", 600, 600, "Place 3", "Stelllenbeschreibung", 0));

            Objects.Add(new Connection("6", "0", "3", 3, "Connbeschreibung"));
            Objects.Add(new Connection("7", "3", "1", 6, "Connbeschreibung"));
            Objects.Add(new Connection("8", "0", "4", 8, "Connbeschreibung"));
            Objects.Add(new Connection("9", "4", "0", 1, "Connbeschreibung"));
            Objects.Add(new Connection("10", "1", "5", 7, "Connbeschreibung"));
            Objects.Add(new Connection("11", "5", "1", 3, "Connbeschreibung"));
            Objects.Add(new Connection("12", "0", "5", 2, "Connbeschreibung"));
            Objects.Add(new Connection("13", "2", "4", 2, "Connbeschreibung"));



        }

        public void InitDependencies()
        {
            foreach (var obj in Objects.GetConnectables())
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
                obj.UpdateArrows();
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
            connection.Source = Objects.FirstOrDefault(o => o.Id == connection.SourceId) as ConnectableBase;
            connection.Destination = Objects.FirstOrDefault(o => o.Id == connection.DestinationId) as ConnectableBase;
            connection.X = connection.Source.X;
            connection.Y = connection.Source.Y;

        }








        public string CreateId()
        {
            string guid = Guid.NewGuid().ToString();
            return guid;
        }
    }
}
