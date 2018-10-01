using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Petri.Editor.Controls
{
    class NumericTextBox : TextBox
    {
        private static readonly Regex allowedRegex = new Regex("[^0-9.-]+");

        public NumericTextBox()
        {
            PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int result;
            bool isNumeric = int.TryParse(e.Text, out result);
            e.Handled = allowedRegex.IsMatch(e.Text);
           
        }

        private static bool IsTextAllowed(string text)
        {
            return !allowedRegex.IsMatch(text);
        }
    }
}
