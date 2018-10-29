using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Helper;

namespace Petri.Logic.Components
{
    [XmlType("Connection")]
    public class Connection : UIPlaceable
    {

        [XmlAttribute("Value")]
        public int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }

        [XmlAttribute("IsExecutable")]
        public bool IsExecutable
        {
            get { return GetProperty(() => IsExecutable); }
            set { SetProperty(() => IsExecutable, value); }
        }

        [XmlIgnore]
        public double ArrowSourceX
        {
            get { return GetProperty(() => ArrowSourceX); }
            set { SetProperty(() => ArrowSourceX, value); }
        }

        

        [XmlIgnore]
        public double ArrowSourceY
        {
            get { return GetProperty(() => ArrowSourceY); }
            set { SetProperty(() => ArrowSourceY, value); }
        }

        [XmlIgnore]
        public double ArrowDestinationX
        {
            get { return GetProperty(() => ArrowDestinationX); }
            set { SetProperty(() => ArrowDestinationX, value); }
        }

        [XmlIgnore]
        public double ArrowDestinationY
        {
            get { return GetProperty(() => ArrowDestinationY); }
            set { SetProperty(() => ArrowDestinationY, value); }
        }

        public void CalcIsExecutable()
        {
            if (Source is Transition transitionSource)
            {
                IsExecutable = transitionSource.IsExecutable;
            }
            else if (Source is Stelle stelleSource)
            {
                IsExecutable = (stelleSource.Value >= Value);
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

        public void UpdateArrows()
        {
            X = Source.X;
            Y = Source.Y;
            double size = 75;
            if (!ArrowManagement.AlreadyCalculated(Source, Destination))
            {
                var _x = 0 + size * 0.25;
                var _y = 0 + size * 0.25;

                ArrowSourceX = _x;
                ArrowSourceY = _y;
                ArrowDestinationX = DestX + size * 0.25;
                ArrowDestinationY = DestY + size * 0.25;

                ArrowManagement.Add(Source, Destination);
            }
            else
            {
                var _x = 0 + size * 0.75;
                var _y = 0 + size * 0.75;

                ArrowSourceX = _x;
                ArrowSourceY = _y;
                ArrowDestinationX = DestX + size * 0.75;
                ArrowDestinationY = DestY + size * 0.75;
            }

            RaisePropertyChanged("X");
            RaisePropertyChanged("Y");
        }


    }
}
