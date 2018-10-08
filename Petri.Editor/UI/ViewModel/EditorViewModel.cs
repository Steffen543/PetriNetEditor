using DevExpress.Mvvm;
using Petri.Logic.Commands;
using Petri.Logic.Components;
using Petri.Logic.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Petri.Editor.Dialogs;
using Petri.Editor.Helper;

namespace Petri.Editor.UI.ViewModel
{
    public class EditorViewModel : ViewModelBase
    {
       
        public PetriNetXML PetriNet
        {
            get { return GetProperty(() => PetriNet); }
            set{ SetProperty(() => PetriNet, value); }
        }

        public UIPlaceable CurrentInformationEntry
        {
            get { return GetProperty(() => CurrentInformationEntry); }
            set{ SetProperty(() => CurrentInformationEntry, value); }
        }




        public EditorMode EditorMode {
            get {  return GetProperty(() => this.EditorMode); }
            set
            {
                if (value != EditorMode.AddConnection)
                {
                    if(AddConnectionHelper.Source != null)
                        AddConnectionHelper.Source.SelectedAsSource = false;
                    AddConnectionHelper.Source = null;
                    AddConnectionHelper.Destination = null;
                }
                SetProperty(() => this.EditorMode, value);
            }
        }

        public AddConnectionHelper AddConnectionHelper
        {
            get {  return GetProperty(() => AddConnectionHelper); }
            set { SetProperty(() => AddConnectionHelper, value); }
        }

        public DelegateCommand<PetriNetCoordinates> AddCommand { get; private set; }
        public DelegateCommand<UIPlaceable> ShowInformationCommand { get; private set; }
        public DelegateCommand<UIPlaceable> DeleteCommand { get; private set; }
        public DelegateCommand<Transition> ExecuteCommand { get; private set; }
        public DelegateCommand<ConnectableBase> AddConnectionCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public EditorViewModel()
        {
            AddConnectionHelper = new AddConnectionHelper();
            AddCommand = new DelegateCommand<PetriNetCoordinates>(AddCommandExecute, AddCommandCanExecute);
            DeleteCommand = new DelegateCommand<UIPlaceable>(DeleteCommandExecute, DeleteCommandCanExecute);
            ExecuteCommand = new DelegateCommand<Transition>(ExecuteCommandExecute, ExecuteCommandCanExecute);
            AddConnectionCommand = new DelegateCommand<ConnectableBase>(AddConnectionCommandExecute, AddConnectionCommandCanExecute);
            ShowInformationCommand = new DelegateCommand<UIPlaceable>(ShowInformationCommandExecute, ShowInformationCommandCanExecute);
            CancelCommand = new DelegateCommand(CancelCommandExecute, CancelCommandCanExecute);
        }

        #region Commands

        void CancelCommandExecute()
        {
            if (AddConnectionHelper.Destination != null)
            {
                AddConnectionHelper.Destination = null;
            }

            if (AddConnectionHelper.Source != null)
            {
                AddConnectionHelper.Source.SelectedAsSource = false;
                AddConnectionHelper.Source = null;
            }
        }

        void ExecuteCommandExecute(Transition item)
        {
            item.Execute();
        }

        void ShowInformationCommandExecute(UIPlaceable item)
        {
            CurrentInformationEntry = item;
        }

        void AddConnectionCommandExecute(ConnectableBase item)
        {
            if (AddConnectionHelper.Source == null)
            {
                AddConnectionHelper.Source = item;
                item.SelectedAsSource = true;
            }
            else if (AddConnectionHelper.Destination == null && item != AddConnectionHelper.Source)
            {
                AddConnectionHelper.Destination = item;
                AddConnection(AddConnectionHelper.Source, AddConnectionHelper.Destination, 1, AddConnectionHelper.Description);
             
                AddConnectionHelper.Source.SelectedAsSource = false;
                item.SelectedAsSource = false;
                AddConnectionHelper.Destination = null;
                AddConnectionHelper.Source = null;
                EditorMode = EditorMode.Execute;
            }
        }

        void DeleteCommandExecute(UIPlaceable item)
        {
            DeleteComponent(item);
        }

        void AddCommandExecute(PetriNetCoordinates coordinates)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            Console.WriteLine($"{EditorMode} on ({x} | {x})");
            switch (EditorMode)
            {
                case EditorMode.AddStelle:
                    AddStelle(x, y, "neu");
                    break;
                case EditorMode.AddTransition:
                    AddTransition(x, y, "neu");
                    break;
            }
        }

        #endregion

        #region CanExecute

        bool CancelCommandCanExecute()
        {
            return true;
        }

        bool ExecuteCommandCanExecute(Transition item)
        {
            return EditorMode == EditorMode.Execute && item != null && item.IsExecutable;
        }

        bool ShowInformationCommandCanExecute(UIPlaceable item)
        {
            return EditorMode == EditorMode.ShowInformation;
        }

        bool AddConnectionCommandCanExecute(ConnectableBase item)
        {
            if (AddConnectionHelper.Source == item)
                return false;
            if (AddConnectionHelper.Source != null && AddConnectionHelper.Source.GetType() == item.GetType())
                return false;
            return EditorMode == EditorMode.AddConnection;
        }

        bool DeleteCommandCanExecute(UIPlaceable item)
        {
            return EditorMode == EditorMode.Delete;
        }

        bool AddCommandCanExecute(PetriNetCoordinates parameter)
        {
            if (EditorMode == EditorMode.AddTransition || EditorMode == EditorMode.AddStelle)
                return true;
            return false;
        }

        #endregion

        #region Logic

        public static EditorViewModel CreateModel(PetriNetXML petriNet)
        {
            EditorViewModel model = new EditorViewModel();
            model.PetriNet = petriNet;
            return model;
        }



        public void AddStelle(double x, double y, string description)
        {
            Stelle stelle = new Stelle(PetriNet.CreateId(), x, y, "Name", "Description",  0);
            PetriNet.Objects.Add(stelle);
            PetriNet.InitDependency(stelle);
        }

        public void AddTransition(double x, double y, string description)
        {
            Transition trans = new Transition(PetriNet.CreateId(), x, y, "Name", "Description");
            PetriNet.Objects.Add(trans);
            PetriNet.InitDependency(trans);
            trans.CalcIsExecutable();
        }

        public void DeleteComponent(UIPlaceable component)
        {
            PetriNet.Objects.Remove(component);
            if (component is Connection conn)
            {
                var related = PetriNet.Objects.GetConnectables().Where(o => o.Id == conn.SourceId || o.Id == conn.DestinationId);
                foreach (var rel in related)
                {
                    PetriNet.InitDependency(rel);
                }
            }
            if (component is ConnectableBase connectable)
            {
                foreach(var outputConn in connectable.Output)
                {
                    DeleteComponent(outputConn);
                }
                foreach (var inputConn in connectable.Input)
                {
                    DeleteComponent(inputConn);
                }
            }
        }

        public void AddConnection(IConnectable source, IConnectable destination, int value, string description)
        {
            Connection newConnection = new Connection(PetriNet.CreateId(), source.Id, destination.Id, value, "NAME", description);
            PetriNet.InitDependency(newConnection);
            PetriNet.Objects.Add(newConnection);
            PetriNet.InitDependency(source as ConnectableBase);
            PetriNet.InitDependency(destination as ConnectableBase);
            newConnection.CalcIsExecutable();
        }

        #endregion
    }
}
