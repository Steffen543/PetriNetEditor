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

        public int MaxValue { get; set; }

        public NumericTextBox()
        {
            PreviewTextInput += NumericTextBox_PreviewTextInput;
            TextChanged += NumericTextBox_TextChanged;
        }

        private void NumericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Text != String.Empty && int.Parse(Text) > MaxValue)
                    Text = MaxValue.ToString();
            }
            catch (Exception ex)
            {
                e.Handled = true;
            }
            
        }

        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int result;
            bool isNumeric = int.TryParse(e.Text, out result);
            e.Handled = allowedRegex.IsMatch(e.Text);
            if (e.Text == "-") e.Handled = true;
        }

        private static bool IsTextAllowed(string text)
        {
            return !allowedRegex.IsMatch(text);
        }
    }
}
