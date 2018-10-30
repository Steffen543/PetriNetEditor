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
    [XmlInclude(typeof(Transition)), XmlInclude(typeof(Place)), XmlInclude(typeof(Connection)), XmlInclude(typeof(ConnectableBase))]
    public class UIPlaceable : BindableBase
    {
        [XmlAttribute("id")]
        public String Id
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

        public UIPlaceable(string id, double x, double y, string description)
        {
            Id = id;
            X = x;
            Y = y;
            Description = description;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

      
      
    }
}
