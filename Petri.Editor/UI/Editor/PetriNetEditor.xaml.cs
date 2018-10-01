using Petri.Editor.UI.ViewModel;
using Petri.Logic.Components;
using Petri.Logic.Data;
using Petri.Logic.Xml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Petri.Editor.UI.Editor
{
    /// <summary>
    /// Interaktionslogik für PetriNetEditor.xaml
    /// </summary>
    public partial class PetriNetEditor : UserControl
    {
        public EditorMode EditorMode { get; set; }


        public PetriNetEditor()
        {
           
           
            InitializeComponent();
            //petriNet.SaveToXML();
        }
    }
}
