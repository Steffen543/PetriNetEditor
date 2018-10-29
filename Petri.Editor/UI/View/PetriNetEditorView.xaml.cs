using System.Windows.Controls;
using Petri.Editor.UI.ViewModel;

namespace Petri.Editor.UI.View
{
    /// <summary>
    /// Interaktionslogik für PetriNetEditorView.xaml
    /// </summary>
    public partial class PetriNetEditorView : UserControl
    {
        public EditorMode EditorMode { get; set; }


        public PetriNetEditorView()
        {
            InitializeComponent();
            EditorDisplay.ZoomSlider = EditorTools.ZoomSlider;
        }
    }
}
