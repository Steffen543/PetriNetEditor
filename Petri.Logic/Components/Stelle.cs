using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Petri.Logic.Components
{
    [XmlType("Stelle")]
    public class Stelle : ConnectableBase, IConnectable
    {
        private int value;

        [XmlIgnore()]
        public ObservableCollection<StellePoint> Points { get; set; }

        [XmlAttribute("Value")]
        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value < 0) value = 0;
                this.value = value;
                RaisePropertyChanged("Value");
                foreach (var outputConnection in Output)
                {
                    var destinationTransition = outputConnection.Destination as Transition;

                    outputConnection.CalcIsExecutable();
                    destinationTransition.CalcIsExecutable();
                }

                Points = new ObservableCollection<StellePoint>();
                for (int i = 0; i < Value; i++)
                {
                    Points.Add(new StelleFullPoint());
                }
                /*for (int i = 0; i < missing; i++)
                {
                    Points.Add(new StelleEmptyPoint());
                }*/
                RaisePropertyChanged("Points");
                RaisePropertyChanged("IsExecutable");

            }
        }

      

        public Stelle()
        {

        }


        public Stelle(int id, double x, double y, string name, string description, int value) : base(id, x, y, description, name)
        {
            Value = value;
        }

        

        public override string ToString()
        {
            return $"Stelle: [Id: {Id.ToString()}, Description: {Description}";
        }
    }

    public class StellePoint
    {

    }

    public class StelleFullPoint : StellePoint
    {

    }

    public class StelleEmptyPoint : StellePoint
    {

    }
}
