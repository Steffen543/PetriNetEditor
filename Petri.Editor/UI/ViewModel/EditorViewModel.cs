using Petri.Logic.Commands;
using Petri.Logic.Components;
using Petri.Logic.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Petri.Editor.UI.ViewModel
{
    public class EditorViewModel : ViewModelBase
    {
        private EditorMode editorMode;
        internal PetriNetXML petriNetXML;

        public EditorMode EditorMode {
            get
            {
                return editorMode;
            }
            set
            {
                editorMode = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<UIPlaceable> Items { get; set; }


        public EditorViewModel()
        {
            Items = new ObservableCollection<UIPlaceable>();
        }


        public void ChangeEditorMode(EditorMode editMode)
        {

        }

        

        public void AddStelle(double x, double y, string description)
        {
            Stelle stelle = new Stelle(petriNetXML.CreateId(), x, y, "NAME", "DESCRIPTION", 5, 0);
            petriNetXML.Stellen.Add(stelle);
            Items.Add(stelle);

        }

        public void AddTransition(double x, double y, string description)
        {
            Transition trans = new Transition(petriNetXML.CreateId(), x, y, "NAME", "DESCRIPTION");
            Items.Add(trans);
            petriNetXML.Transitions.Add(trans);
            AddTransitionCommand command = new AddTransitionCommand();
            Console.WriteLine("addTransition executed()");
        }

        public void DeleteComponent(UIPlaceable component)
        {

        }

        public void AddConnection(IConnectable source, IConnectable destination, int value, string description)
        {
            Connection newConnection = new Connection(petriNetXML.CreateId(), source.Id, destination.Id, value, "NAME", description);
            petriNetXML.InitDependency(newConnection);
            petriNetXML.Connections.Add(newConnection);
            Items.Insert(0, newConnection);
            petriNetXML.InitDependency(source as ConnectableBase);
            petriNetXML.InitDependency(destination as ConnectableBase);
        }
    }
}
