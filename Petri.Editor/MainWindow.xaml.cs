using Petri.Editor.UI.ViewModel;
using Petri.Logic.Data;
using Petri.Logic.Xml;
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

namespace Petri.Editor
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public PetriNetXML CurrentPetriNet { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            PetriNetXMLReader reader = new PetriNetXMLReader();
            CurrentPetriNet = reader.ReadFromXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml");
            //CurrentPetriNet = new PetriNetXML();
            //CurrentPetriNet.AddTestEntries();
            CurrentPetriNet.InitDependencies();
            PetriEditor.DataContext = EditorViewModel.CreateModel(CurrentPetriNet);
            instance = this;
        }

        private void SavePetriNet(object sender, RoutedEventArgs e)
        {
            PetriNetXMLReader reader = new PetriNetXMLReader();
            reader.SaveToXML(CurrentPetriNet, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml");
        }

        private void OpenPetriNet(object sender, RoutedEventArgs e)
        {
            PetriNetXMLReader reader = new PetriNetXMLReader();
            CurrentPetriNet = reader.ReadFromXML(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml");
            CurrentPetriNet.InitDependencies();
            PetriEditor.DataContext = EditorViewModel.CreateModel(CurrentPetriNet);
        }

        public static MainWindow GetInstance()
        {
            return instance;
        }
    }
}
