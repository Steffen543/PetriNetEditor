using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.PNML;

namespace Petri.Logic.Components
{
    [XmlType("place")]
    public class Place : ConnectableBase, IConnectable
    {
        private PNML_InitialMarking _value;

        [XmlIgnore()]
        public ObservableCollection<PlacePoint> Points { get; set; }

        [XmlElement("initialMarking")]
        public PNML_InitialMarking Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.Text < 0) _value = new PNML_InitialMarking(0);
                this._value = value;
               
                foreach (var outputConnection in Output)
                {
                    var destinationTransition = outputConnection.Destination as Transition;

                    outputConnection.CalcIsExecutable();
                    destinationTransition.CalcIsExecutable();
                }

                Points = new ObservableCollection<PlacePoint>();
                for (int i = 0; i < value.Text; i++)
                {
                    Points.Add(new PlaceFullPoint());
                }
                RaisePropertyChanged("Points");
                RaisePropertyChanged("IsExecutable");
                RaisePropertyChanged("Value");

            }
        }

      

        public Place()
        {

        }


        public Place(string id, double x, double y, string name, string description, int value) : base(id, x, y, description, name)
        {
            Value = new PNML_InitialMarking(value);
        }

        

        public override string ToString()
        {
            return $"Place: [Id: {Id.ToString()}, Description: {Description}";
        }
    }

    public class PlacePoint
    {

    }

    public class PlaceFullPoint : PlacePoint
    {

    }

    public class PlaceEmptyPoint : PlacePoint
    {

    }
}
