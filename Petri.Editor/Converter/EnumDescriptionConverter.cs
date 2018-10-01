using Petri.Editor.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Petri.Editor.Converter
{
    [ValueConversion(typeof(object), typeof(EditorMode))]
    class EnumDescriptionConverter : BaseConverter, IValueConverter
    {
        private string GetEnumDescription(Enum enumObj)
        {
            FieldInfo info = enumObj.GetType().GetField(enumObj.ToString());
            object[] attributeArray = info.GetCustomAttributes(false);

            if (attributeArray.Length != 0)
            {
                DescriptionAttribute attrib = attributeArray[0] as DescriptionAttribute;
                return attrib.Description;
            }
            else
            {
                return enumObj.ToString();
            }
        }

        public object Convert(object value, Type targetType, object parameter,
           System.Globalization.CultureInfo culture)
        {
            Enum myEnum = (Enum)value;
            string description = GetEnumDescription(myEnum);
            return description;

        }

        public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
