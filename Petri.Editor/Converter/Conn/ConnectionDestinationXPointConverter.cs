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
    class ConnectionDestinationXPointConverter : BaseConverter, IValueConverter
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
                var x = conn.DestX + size * 0.25;
                var newPoint = new RoundLineModdlePointPosition(conn.Source, conn.Destination, new Point(0, 0));
                Points.Add(newPoint);
                return x;
            }
            else
            {
                var x = conn.DestX + size * 0.75;
                return x;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
}
}
