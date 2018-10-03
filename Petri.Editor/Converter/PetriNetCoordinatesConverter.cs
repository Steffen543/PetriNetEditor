using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Petri.Editor.Helper;

namespace Petri.Editor.Converter
{
    public class PetriNetCoordinatesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            var obj = (ItemsControl)value;
            PetriNetCoordinates coordinates = new PetriNetCoordinates(obj);
            return coordinates;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return null;
        }

        
    }

}
