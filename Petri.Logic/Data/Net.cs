using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Components;
using Petri.Logic.Pnml;

namespace Petri.Logic.Data
{
    public class Net
    {
        public Name name { get; set; }

        [XmlArray("page")]
        [XmlArrayItem("transition", Type = typeof(Transition))]
        [XmlArrayItem("arc", Type = typeof(Connection))]
        [XmlArrayItem("place", Type = typeof(Place))]
        public ObjectList Objects { get; set; }

        public Net()
        {
            Objects = new ObjectList();
        }

        /// <summary>
        /// Adds Test Entries to the Object-List
        /// </summary>
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

        /// <summary>
        /// Initializes the dependencies for all objects in the Objects-List and
        /// initializes the Properties for the logic. Also adds a new Position if the entries
        /// dont have a position loaded from the xml.
        /// </summary>
        public void InitDependencies()
        {
            foreach (var obj in Objects.GetConnectables())
            {
                if (obj.Position == null) obj.Position = new Position(0, 0);
                InitDependency(obj);
                obj.Position.PropertyChanged += obj.PositionChanged;
            }

            foreach (var obj in Objects.GetConnections())
            {
                if (obj.Position == null) obj.Position = new Position(0, 0);
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

        /// <summary>
        /// Initializes the dependencies for a ConnectableBase-Object.
        /// Adds the destination-connections to the output and the source-connections
        /// to the input.
        /// </summary>
        /// <param name="connectable">Connectable</param>
        public void InitDependency(ConnectableBase connectable)
        {
            var destinations = Objects.GetConnections().Where(c => c.SourceId == connectable.Id);
            var sources = Objects.GetConnections().Where(c => c.DestinationId == connectable.Id);

            connectable.Input = new ObservableCollection<Connection>(sources);
            connectable.Output = new ObservableCollection<Connection>(destinations);
            connectable.Position.PropertyChanged += connectable.PositionChanged;
        }

        /// <summary>
        /// Initializes the dependencies for a Connection-Object.
        /// Adds the Source- and the Destination-Object and sets the X and Y
        /// position.
        /// </summary>
        /// <param name="connection">Connection</param>
        public void InitDependency(Connection connection)
        {
            connection.Source = Objects.FirstOrDefault(o => o.Id == connection.SourceId) as ConnectableBase;
            connection.Destination = Objects.FirstOrDefault(o => o.Id == connection.DestinationId) as ConnectableBase;
            connection.Position.X = connection.Source.Position.X;
            connection.Position.Y = connection.Source.Position.Y;
        }

        /// <summary>
        /// Creates a random GUID
        /// </summary>
        /// <returns>The GUID</returns>
        public string CreateId()
        {
            string guid = Guid.NewGuid().ToString();
            return guid;
        }
    }
}
