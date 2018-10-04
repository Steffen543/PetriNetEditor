using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Petri.Editor.UI.ViewModel;
using Petzold.Media2D;

namespace Petri.Editor.Converter
{
    class EqualsConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty EditorViewModelProperty =
            DependencyProperty.Register("EditorViewModel",
                typeof(EditorViewModel), typeof(EqualsConverter),
                new FrameworkPropertyMetadata(null,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        /// <summary>
        ///     Gets or sets the x-coordinate of the ArrowLine start point.
        /// </summary>
        public EditorViewModel EditorViewModel
        {
            set { SetValue(EditorViewModelProperty, value); }
            get { return (EditorViewModel)GetValue(EditorViewModelProperty); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
