﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Petri.Editor.Converter
{
    [ValueConversion(typeof(object), typeof(object))]
    class ConnectionColorConverter : BaseConverter, IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            bool executable = (bool)value;
            if(executable == true)
            {
                return Brushes.Green;
            }
            return Brushes.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
