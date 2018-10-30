using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Microsoft.Win32;
using Petri.Logic.Data;
using Petri.Logic.Xml;

namespace Petri.Editor.UI.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public PnmlNet CurrentPnmlNet
        {
            get { return GetProperty(() => CurrentPnmlNet); }
            set
            {
                EditorViewModel.PnmlNet = value;
                SetProperty(() => CurrentPnmlNet, value); 
            }
        }

        public EditorViewModel EditorViewModel
        {
            get { return GetProperty(() => EditorViewModel); }
            set { SetProperty(() => EditorViewModel, value); }
        }

        public string CurrentFileName
        {
            get { return GetProperty(() => CurrentFileName); }
            set { SetProperty(() => CurrentFileName, value); }
        }

        public string CurrentFilePath
        {
            get { return GetProperty(() => CurrentFilePath); }
            set { SetProperty(() => CurrentFilePath, value); }
        }

        public DelegateCommand CreateNewPetriNetCommand { get; private set; }
        public DelegateCommand OpenPetriNetFileCommand { get; private set; }
        public DelegateCommand SavePetriNetCommand { get; private set; }
        public DelegateCommand SavePetriNetUnderNewNameCommand { get; private set; }

        public MainWindowViewModel()
        {
            CreateNewPetriNetCommand = new DelegateCommand(CreateNewPetriNetCommandExecute, CreateNewPetriNetCommandCanExecute);
            OpenPetriNetFileCommand = new DelegateCommand(OpenPetriNetFileCommandExecute, OpenPetriNetFileCommandCanExecute);
            SavePetriNetCommand = new DelegateCommand(SavePetriNetCommandExecute, SavePetriNetCommandCanExecute);
            SavePetriNetUnderNewNameCommand = new DelegateCommand(SavePetriNetUnderNewNameCommandExecute, SavePetriNetUnderNewNameCommandCanExecute);
            EditorViewModel = new EditorViewModel();
            //CurrentPnmlNet = new PnmlNet();
        }

        #region Commands

        void CreateNewPetriNetCommandExecute()
        {
            CurrentPnmlNet = new PnmlNet();
        }

        void OpenPetriNetFileCommandExecute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 0;
            openFileDialog.DefaultExt = "xml";
            if(openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;

                CurrentFileName = openFileDialog.FileName;
                CurrentFilePath = file;

                PetriNetXMLReader reader = new PetriNetXMLReader();
                CurrentPnmlNet = reader.ReadFromXML(file);
                CurrentPnmlNet.PetriNet.InitDependencies();
            }
        }

        void SavePetriNetCommandExecute()
        {
            PetriNetXMLReader reader = new PetriNetXMLReader();

            if (CurrentFileName != null)
            {
                reader.SaveToXML(CurrentPnmlNet, CurrentFilePath);
            }
            else
            {
                SavePetriNetUnderNewNameCommandExecute();
            }
        }

        void SavePetriNetUnderNewNameCommandExecute()
        {
            PetriNetXMLReader reader = new PetriNetXMLReader();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.FileName = "Petrinet.xml";

            if (saveFileDialog.ShowDialog() == true)
            {
                reader.SaveToXML(CurrentPnmlNet, saveFileDialog.FileName);
            }
        }

        #endregion

        #region CanExecute

        bool CreateNewPetriNetCommandCanExecute()
        {
            return true;
        }
        bool OpenPetriNetFileCommandCanExecute()
        {
            return true;
        }
        bool SavePetriNetCommandCanExecute()
        {
            return CurrentPnmlNet != null;
        }
        bool SavePetriNetUnderNewNameCommandCanExecute()
        {
            return CurrentPnmlNet != null;
        }


        #endregion

    }
}
