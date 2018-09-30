using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Petri.Editor.Converter
{
    [ValueConversion(typeof(object), typeof(Transition))]
    class ButtonExecutableConverter : BaseConverter, IValueConverter
    {
      

        public object Convert(object value, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
