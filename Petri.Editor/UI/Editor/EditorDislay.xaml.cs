using Petri.Editor.Dialogs;
using Petri.Editor.Helper;
using Petri.Editor.UI.ViewModel;
using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Petri.Editor.UI.Editor
{
    /// <summary>
    /// Interaktionslogik für EditorDislay.xaml
    /// </summary>
    public partial class EditorDislay : UserControl
    {
        public EditorDislay()
        {
            InitializeComponent();
        }

        private void Arrow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

    }
}
