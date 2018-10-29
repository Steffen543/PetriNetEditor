using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Petri.Editor.Converter.Conn
{
    [ValueConversion(typeof(object), typeof(Connection))]
    class ConnectionDestinationYPointConverter : IMultiValueConverter
    {
        public static List<RoundLineModdlePointPosition> Points = new List<RoundLineModdlePointPosition>();

        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Connection conn = (Connection)values[0];
            double size = (double)Application.Current.FindResource("TransitionSize");

            var connectionAlreadyDrawn = Points.FirstOrDefault(p => p.Contains(conn.Source, conn.Destination));

            if (connectionAlreadyDrawn == null)
            {
                var y = conn.DestY + size * 0.25;
                var newPoint = new RoundLineModdlePointPosition(conn.Source, conn.Destination, new Point(0, 0));
                Points.Add(newPoint);
                return y;
            }
            else
            {
                var y = conn.DestY + size * 0.75;
                return y;
            }

        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
