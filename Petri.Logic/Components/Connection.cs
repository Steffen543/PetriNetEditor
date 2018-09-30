using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Petri.Logic.Components
{
    [XmlType("Connection")]
    public class Connection : UIPlaceable
    {
        private int value;

        [XmlAttribute("Value")]
        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                NotifyPropertyChanged();
            }
        }

        [XmlAttribute("SourceId")]
        public int SourceId { get; set; }

        [XmlAttribute("DestinationId")]
        public int DestinationId { get; set; }

        public double DestX {
            get
            {
                return Destination.X - X;
                
            }
        }
        public double DestY
        {
            get
            {
                return Destination.Y - Y;
            }
        }

        [XmlIgnore]
        public IConnectable Source { get; set; }

        [XmlIgnore]
        public IConnectable Destination {  get; set; }

        public Connection()
        {

        }

        public Connection(int id, int sourceId, int destinationId, int value, string name, string description) : base(id, 0, 0, description, name)
        {
            Value = value;
            SourceId = sourceId;
            DestinationId = destinationId;
        }

        public override string ToString()
        {
            return $"Connection: [Id: {Id.ToString()}, SourceId: {SourceId}, DestinationId: {DestinationId}, Description: {Description}";
        }


    }
}
