using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Helper;
using Petri.Logic.Pnml;

namespace Petri.Logic.Components
{
    [XmlType("arc")]
    public class Connection : UIPlaceable
    {
        [XmlAttribute("source")]
        public string SourceId { get; set; }

        [XmlAttribute("target")]
        public string DestinationId { get; set; }

        [XmlElement("inscription")]
        public ConnectionInscription Value
        {
            get { return GetProperty(() => Value); }
            set
            {
                SetProperty(() => Value, value);
                if(Destination is Transition trans) trans.CalcIsExecutable();
                CalcIsExecutable();
            }
        }

        [XmlIgnore]
        public bool IsExecutable
        {
            get { return GetProperty(() => IsExecutable); }
            set { SetProperty(() => IsExecutable, value); }
        }

        [XmlIgnore]
        public Position SourcePosition
        {
            get { return GetProperty(() => SourcePosition); }
            set { SetProperty(() => SourcePosition, value); }
        }

        [XmlIgnore]
        public Position DestinationPosition
        {
            get { return GetProperty(() => DestinationPosition); }
            set { SetProperty(() => DestinationPosition, value); }
        }

        public double DestX {
            get
            {
                return Destination.Position.X - Position.X;
                
            }
        }
        public double DestY
        {
            get
            {
                return Destination.Position.Y - Position.Y;
            }
        }

        [XmlIgnore]
        public ConnectableBase Source { get; set; }

        [XmlIgnore]
        public ConnectableBase Destination {  get; set; }

        public Connection()
        {
            SourcePosition = new Position();
            DestinationPosition = new Position();
        }

        public Connection(string id, string sourceId, string destinationId, int value, string description) : base(id, 0, 0, description)
        {
            Value = new ConnectionInscription(value);
            SourceId = sourceId;
            DestinationId = destinationId;
            SourcePosition = new Position();
            DestinationPosition = new Position();
        }

        public override string ToString()
        {
            return $"Connection: [Id: {Id.ToString()}, SourceId: {SourceId}, DestinationId: {DestinationId}, Description: {Description}";
        }

        public void CalcIsExecutable()
        {
            if (Source is Transition transitionSource)
            {
                IsExecutable = transitionSource.IsExecutable;
            }
            else if (Source is Place placeSource)
            {
                IsExecutable = (placeSource.Value.Text >= Value.Text);
            }
        }

        public void UpdateArrows()
        {
            Position.X = Source.Position.X;
            Position.Y = Source.Position.Y;
            double size = ConnectableBase.SIZE;
           
            if (ArrowManagement.CountAllConnections(Source, Destination) == 1)
            {
                var _x = 0 + size * 0.5;
                var _y = 0 + size * 0.5;

                SourcePosition.X = _x;
                SourcePosition.Y = _y;
                DestinationPosition.X = DestX + size * 0.5;
                DestinationPosition.Y = DestY + size * 0.5;
               

                ArrowManagement.Add(Source, Destination, 0.5);
            }
            else
            {
                var containsOne = ArrowManagement.AlreadyContainsConnection(Source, Destination);
                if (containsOne == null)
                {
                    var _x = 0 + size * 0.25;
                    var _y = 0 + size * 0.25;

                    SourcePosition.X = _x;
                    SourcePosition.Y = _y;
                    DestinationPosition.X = DestX + size * 0.25;
                    DestinationPosition.Y = DestY + size * 0.25;

                    ArrowManagement.Add(Source, Destination, 0.25);
                }
                else
                {
                    var _x = 0 + size * 0.75;
                    var _y = 0 + size * 0.75;

                    SourcePosition.X = _x;
                    SourcePosition.Y = _y;
                    DestinationPosition.X = DestX + size * 0.75;
                    DestinationPosition.Y = DestY + size * 0.75;
                }
            }

            RaisePropertyChanged("X");
            RaisePropertyChanged("Y");
        }


    }
}
