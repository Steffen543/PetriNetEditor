using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Petri.Editor.Converter
{

    class StellePointConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var currentValue = (int) values[0];
            var maxValue = (int) values[1];
            var missing = maxValue - currentValue;

            ObservableCollection<StellePoint> list = new ObservableCollection<StellePoint>();
           
            for (int i = 0; i < currentValue; i++)
            {
                list.Add(new StelleFullPoint());
            }
            for (int i = 0; i < missing; i++)
            {
                list.Add(new StelleEmptyPoint());
            }

            return list;
        }

        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

      
    }

    public class StellePoint
    {

    }

    public class StelleFullPoint : StellePoint
    {

    }

    public class StelleEmptyPoint : StellePoint
    {

    }
}
