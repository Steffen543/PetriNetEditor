using System.Windows.Controls;
using System.Windows.Input;

namespace Petri.Editor.UI.View
{
    /// <summary>
    /// Interaktionslogik für EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl
    {
        public EditorView()
        {
            InitializeComponent();
        }

        private void Arrow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

    }
}
