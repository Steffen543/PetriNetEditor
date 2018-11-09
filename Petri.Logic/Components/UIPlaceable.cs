using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;
using Petri.Logic.Pnml;

namespace Petri.Logic.Components
{
    [XmlType("UIPlaceable")]
    [XmlInclude(typeof(Transition)), XmlInclude(typeof(Place)), XmlInclude(typeof(Connection)), XmlInclude(typeof(ConnectableBase))]
    public class UIPlaceable : BindableBase
    {
        [XmlAttribute("id")]
        public string Id
        {
            get { return GetProperty(() => Id); }
            set { SetProperty(() => Id, value); }
        }

        [XmlElement("Description")]
        public string Description
        {
            get { return GetProperty(() => Description); }
            set { SetProperty(() => Description, value); }
        }
    

    [XmlElement("position")]
        public Position Position
        {
            get { return GetProperty(() => Position); }
            set { SetProperty(() => Position, value); }
        }

    
        public UIPlaceable() { }

        public UIPlaceable(string id, double x, double y, string description)
        {
            Position = new Position();
            Id = id;
            Position.X = x;
            Position.Y = y;
            Description = description;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

      
      
    }
}
