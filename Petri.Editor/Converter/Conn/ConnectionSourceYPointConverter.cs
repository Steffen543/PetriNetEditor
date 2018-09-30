using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Petri.Editor.Converter.Conn
{
    [ValueConversion(typeof(object), typeof(Connection))]
    class ConnectionSourceYPointConverter : BaseConverter, IValueConverter
    {
        public static List<RoundLineModdlePointPosition> Points = new List<RoundLineModdlePointPosition>();

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Connection conn = (Connection)value;
            double size = (double)Application.Current.FindResource("TransitionSize");

            var connectionAlreadyDrawn = Points.FirstOrDefault(p => p.Contains(conn.Source, conn.Destination));

            if (connectionAlreadyDrawn == null)
            {
                var y = 0 + size * 0.25;
                var newPoint = new RoundLineModdlePointPosition(conn.Source, conn.Destination, new Point(0, 0));
                Points.Add(newPoint);
                return y;
            }
            else
            {
                var y = 0 + size * 0.75;
                return y;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
  
    }

    public class RoundLineModdlePointPosition
    {
        public IConnectable Component1 { get; set; }
        public IConnectable Component2 { get; set; }
        public Point MiddlePosition { get; set; }

        public RoundLineModdlePointPosition(IConnectable component1, IConnectable component2, Point middlePoint)
        {
            Component1 = component1;
            Component2 = component2;
            MiddlePosition = middlePoint;
        }

        public bool Contains(IConnectable component1, IConnectable component2)
        {
            bool oneFound = false;
            bool twoFound = false;
            oneFound = component1 == Component1 || component1 == Component2;
            twoFound = component2 == Component1 || component2 == Component2;
            return oneFound && twoFound;
        }


    }
}
