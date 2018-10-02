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

    public static class PetriNetCoordinatesConverterHelper
    {
        public static IEnumerable<DependencyObject> getChilds(this DependencyObject parent)
        {
            if (parent == null) yield break;

            //use the logical tree for content / framework elements
            foreach (object obj in LogicalTreeHelper.GetChildren(parent))
            {
                var depObj = obj as DependencyObject;
                if (depObj != null)
                    yield return depObj;
            }

            //use the visual tree for Visual / Visual3D elements
            if (parent is Visual || parent is Visual3D)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    yield return VisualTreeHelper.GetChild(parent, i);
                }
            }
        }
    }
}
