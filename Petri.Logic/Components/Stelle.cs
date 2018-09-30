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
        private int maxValue;
        private int value;

        [XmlIgnore()]
        public ObservableCollection<StellePoint> Points { get; set; }

        public bool IsExecutable
        {
            get
            {
                if (Value == MaxValue) return true;
                return false;
            }
        }

        [XmlAttribute("MaxValue")]
        public int MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                NotifyPropertyChanged();
            }
        }

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
                if (value > MaxValue) value = MaxValue;
                this.value = value;
                NotifyPropertyChanged();
                foreach (var outputConnection in Output)
                {
                    ((Transition)outputConnection.Destination).NotifyPropertyChanged("IsExecutable");
                }


                var missing = MaxValue - Value;
                Points = new ObservableCollection<StellePoint>();
                for (int i = 0; i < Value; i++)
                {
                    Points.Add(new StelleFullPoint());
                }
                for (int i = 0; i < missing; i++)
                {
                    Points.Add(new StelleEmptyPoint());
                }
                NotifyPropertyChanged("Points");
                NotifyPropertyChanged("IsExecutable");

            }
        }

      

        public Stelle()
        {

        }


        public Stelle(int id, double x, double y, string name, string description, int maxValue, int value) : base(id, x, y, description, name)
        {
            MaxValue = maxValue;
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
