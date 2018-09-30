using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Petri.Editor.Converter.Conn
{
    [ValueConversion(typeof(object), typeof(double))]
    class HalfValueConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            double margin = 0;
            if (parameter != null)
                Double.TryParse(parameter.ToString(), out margin);

            return (((double)value) / 2) + margin;

        }

        public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
