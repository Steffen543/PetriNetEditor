using DevExpress.Mvvm;
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
using GongSolutions.Wpf.DragDrop;
using Petri.Editor.Converter.Conn;
using Petri.Editor.Dialogs;
using Petri.Editor.Helper;
using Petri.Logic.Helper;

namespace Petri.Editor.UI.ViewModel
{
    public class EditorViewModel : ViewModelBase, IDropTarget
    {

      
        public PnmlNet PnmlNet
        {
            get { return GetProperty(() => PnmlNet); }
            set{ SetProperty(() => PnmlNet, value); }
        }

        public ConnectableBase CurrentInformationEntry
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
        public DelegateCommand<ConnectableBase> ShowInformationCommand { get; private set; }
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
            ShowInformationCommand = new DelegateCommand<ConnectableBase>(ShowInformationCommandExecute, ShowInformationCommandCanExecute);
            CancelCommand = new DelegateCommand(CancelCommandExecute, CancelCommandCanExecute);
        }

        #region Commands

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            var sourceItem = dropInfo.Data;

            if (sourceItem != null)
            {
                dropInfo.Effects = DragDropEffects.Move;
            }

        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            double size = ConnectableBase.SIZE;
            var sourceItem = dropInfo.Data;
            
            if (sourceItem is ConnectableBase item)
            {
                item.Position.X = dropInfo.DropPosition.X - size / 2;
                item.Position.Y = dropInfo.DropPosition.Y - size / 2;

              
                foreach (var connection in item.Output)
                {
                    ArrowManagement.Remove(connection.Source, connection.Destination);
                }
                foreach (var connection in item.Input)
                {
                    ArrowManagement.Remove(connection.Source, connection.Destination);
                }

                foreach (var connection in item.Output)
                {
                    connection.UpdateArrows();
                }
                foreach (var connection in item.Input)
                {
                    connection.UpdateArrows();
                }
            }
        }


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

        void ShowInformationCommandExecute(ConnectableBase item)
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
                AddConnection(AddConnectionHelper.Source, AddConnectionHelper.Destination, 1,
                    AddConnectionHelper.Description);

                AddConnectionHelper.Source.SelectedAsSource = false;
                item.SelectedAsSource = false;
                AddConnectionHelper.Destination = null;
                AddConnectionHelper.Source = null;
                
               
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
                case EditorMode.AddPlace:
                    AddPlace(x, y, "neu");
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

        bool ShowInformationCommandCanExecute(ConnectableBase item)
        {
            return EditorMode == EditorMode.ShowInformation;
        }

        bool AddConnectionCommandCanExecute(ConnectableBase item)
        {
            if (AddConnectionHelper.Source == item)
                return false;
            if (AddConnectionHelper.Source != null && AddConnectionHelper.Source.GetType() == item.GetType())
                return false;
            if (AddConnectionHelper.Source != null &&
                AddConnectionHelper.Source.Output.Count(i => i.Destination == item) > 0)
                return false;
            return EditorMode == EditorMode.AddConnection;
        }

        bool DeleteCommandCanExecute(UIPlaceable item)
        {
            return EditorMode == EditorMode.Delete;
        }

        bool AddCommandCanExecute(PetriNetCoordinates parameter)
        {
            if (EditorMode == EditorMode.AddTransition || EditorMode == EditorMode.AddPlace)
                return true;
            return false;
        }

        #endregion

        #region Logic

        public void AddPlace(double x, double y, string description)
        {
            Place place = new Place(PnmlNet.PetriNet.CreateId(), x, y, "Name", "Description",  0);
            PnmlNet.PetriNet.Objects.Add(place);
            PnmlNet.PetriNet.InitDependency(place);
        }

        public void AddTransition(double x, double y, string description)
        {
            Transition trans = new Transition(PnmlNet.PetriNet.CreateId(), x, y, "Name", "Description");
            PnmlNet.PetriNet.Objects.Add(trans);
            PnmlNet.PetriNet.InitDependency(trans);
            trans.CalcIsExecutable();
        }

        public void DeleteComponent(UIPlaceable component)
        {
            PnmlNet.PetriNet.Objects.Remove(component);
            if (component is Connection conn)
            {
                var related = PnmlNet.PetriNet.Objects.GetConnectables().Where(o => o.Id == conn.SourceId || o.Id == conn.DestinationId);
                foreach (var rel in related)
                {
                    PnmlNet.PetriNet.InitDependency(rel);
                }

                ArrowManagement.Remove(conn.Source, conn.Destination);
                var otherConnectionsBetweenRemoved =
                    PnmlNet.PetriNet.Objects.GetAllConnectionsBetween2Connectables(conn.Source, conn.Destination);
                foreach (var c in otherConnectionsBetweenRemoved)
                {
                    c.UpdateArrows();
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

        public void AddConnection(ConnectableBase source, ConnectableBase destination, int value, string description)
        {
            Connection updateOldConnection = null;
            if (ArrowManagement.CountConnections(source, destination) == 1)
            {
                updateOldConnection = PnmlNet.PetriNet.Objects
                    .GetAllConnectionsBetween2Connectables(source, destination).First();
                ArrowManagement.Remove(source, destination);
            }

            Connection newConnection = new Connection(PnmlNet.PetriNet.CreateId(), source.Id, destination.Id, value, description);
            PnmlNet.PetriNet.InitDependency(newConnection);
            PnmlNet.PetriNet.Objects.Add(newConnection);
            PnmlNet.PetriNet.InitDependency(source);
            PnmlNet.PetriNet.InitDependency(destination);
            if(source is Transition trans) trans.CalcIsExecutable();
            if(destination is Transition transd) transd.CalcIsExecutable();
            newConnection.CalcIsExecutable();

            if(updateOldConnection != null) updateOldConnection.UpdateArrows();

            newConnection.UpdateArrows();
        }

        #endregion
    }
}
