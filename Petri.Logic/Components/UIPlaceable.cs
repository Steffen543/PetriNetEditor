using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.Components
{
    [XmlType("UIPlaceable")] // define Type
    [XmlInclude(typeof(Transition)), XmlInclude(typeof(Stelle)), XmlInclude(typeof(Connection)), XmlInclude(typeof(ConnectableBase))]
    public class UIPlaceable : ViewModelBase
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("X")]
        public double X { get; set; }

        [XmlAttribute("Y")]
        public double Y { get; set; }

        public UIPlaceable() { }

        public UIPlaceable(int id, double x, double y, string description, string name)
        {
            Id = id;
            X = x;
            Y = y;
            Description = description;
            Name = name;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

      
      
    }
}
