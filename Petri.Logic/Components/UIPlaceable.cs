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
    public class UIPlaceable : BindableBase
    {
        [XmlAttribute("Id")]
        public int Id
        {
            get { return GetProperty(() => Id); }
            set { SetProperty(() => Id, value); }
        }

        [XmlAttribute("Name")]
        public string Name
        {
            get { return GetProperty(() => Name); }
            set { SetProperty(() => Name, value); }
        }

        [XmlAttribute("Description")]
        public string Description
        {
            get { return GetProperty(() => Description); }
            set { SetProperty(() => Description, value); }
        }

        [XmlAttribute("X")]
        public double X
        {
            get { return GetProperty(() => X); }
            set { SetProperty(() => X, value); }
        }

        [XmlAttribute("Y")]
        public double Y
        {
            get { return GetProperty(() => Y); }
            set { SetProperty(() => Y, value); }
        }

     

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
