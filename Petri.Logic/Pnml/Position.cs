using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace Petri.Logic.Pnml
{
    public class Position : BindableBase
    {
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

        public Position() { }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
