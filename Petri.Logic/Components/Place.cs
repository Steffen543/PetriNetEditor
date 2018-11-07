using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Pnml;

namespace Petri.Logic.Components
{
    [XmlType("place")]
    public class Place : ConnectableBase
    {
        private PlaceInitialMarking _value;

        [XmlIgnore()]
        public ObservableCollection<PlacePoint> Points { get; set; }


        /// <summary>
        /// Only for binding
        /// </summary>
        [XmlIgnore()]
        public int ValueBind
        {
            get { return GetProperty(() => ValueBind); }
            set
            {
                SetProperty(() => ValueBind, value);
                Value = new PlaceInitialMarking(value);
            }
        }

        [XmlElement("initialMarking")]
        public PlaceInitialMarking Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.Text < 0) _value = new PlaceInitialMarking(0);
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
                    Points.Add(new PlacePoint());
                }
                RaisePropertyChanged("Points");
                RaisePropertyChanged("IsExecutable");
                RaisePropertyChanged("Value");
                SetProperty(() => ValueBind, value.Text);
                RaisePropertiesChanged("ValueBind");

            }
        }

      

        public Place()
        {

        }


        public Place(string id, double x, double y, string name, string description, int value) : base(id, x, y, name, description)
        {
            Value = new PlaceInitialMarking(value);
        }

        

        public override string ToString()
        {
            return $"Place: [Id: {Id.ToString()}, Description: {Description}";
        }
    }

    public class PlacePoint
    {

    }

}
