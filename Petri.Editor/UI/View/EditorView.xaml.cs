using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Petri.Editor.Helper;
using Petri.Editor.UI.View.Manager;

namespace Petri.Editor.UI.View
{
    /// <summary>
    /// Interaktionslogik für EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl
    {
        private Slider _zoomSlider;

        public Slider ZoomSlider
        {
            get { return _zoomSlider; }
            set
            {
                _zoomSlider = value;
                ScrollZoomManager zoomManager = new ScrollZoomManager(MainItemsControl, _zoomSlider);
            }
        }

        public EditorView()
        {
            InitializeComponent();
        }
    }
}
