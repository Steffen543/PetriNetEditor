using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Petri.Editor.Controls
{
    /// <summary>
    /// Interaktionslogik für EditConnectionValueControl.xaml
    /// </summary>
    public partial class EditConnectionValueControl : UserControl
    {
        public EditConnectionValueControl()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EditMode(true);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            EditMode(false);
        }

        public void EditMode(bool edit)
        {
            if(edit)
            {
                MainTextBlock.Visibility = Visibility.Collapsed;
                MainTextBox.Visibility = Visibility.Visible;
                MainButton.Visibility = Visibility.Visible;
                MainTextBox.Focus();
                MainTextBox.SelectAll();
            }
            else
            {
                MainTextBlock.Visibility = Visibility.Visible;
                MainTextBox.Visibility = Visibility.Collapsed;
                MainButton.Visibility = Visibility.Collapsed;
            }
        }

        private void MainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                EditMode(false);
        }
    }
}
