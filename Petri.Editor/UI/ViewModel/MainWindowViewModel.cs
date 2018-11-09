using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using Microsoft.Win32;
using Petri.Editor.Properties;
using Petri.Logic.Data;
using Petri.Logic.Xml;

namespace Petri.Editor.UI.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<LastOpenedFile> LastOpenedFiles
        {
            get { return GetProperty(() => LastOpenedFiles); }
            set { SetProperty(() => LastOpenedFiles, value); }
        }

        public PnmlNet CurrentPnmlNet
        {
            get { return GetProperty(() => CurrentPnmlNet); }
            set
            {
                EditorViewModel.PnmlNet = value;
                SetProperty(() => CurrentPnmlNet, value);
                CurrentPnmlNet.InitArrowManagement();
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

        public bool IsSaved
        {
            get { return GetProperty(() => IsSaved); }
            set { SetProperty(() => IsSaved, value); }
        }

        public DelegateCommand CreateNewPetriNetCommand { get; private set; }
        public DelegateCommand OpenPetriNetFileCommand { get; private set; }
        public DelegateCommand SavePetriNetCommand { get; private set; }
        public DelegateCommand SavePetriNetUnderNewNameCommand { get; private set; }
        public DelegateCommand<LastOpenedFile> OpenLastPetriNetFileCommand { get; private set; }

        public MainWindowViewModel()
        {
            CreateNewPetriNetCommand = new DelegateCommand(CreateNewPetriNetCommandExecute, CreateNewPetriNetCommandCanExecute);
            OpenPetriNetFileCommand = new DelegateCommand(OpenPetriNetFileCommandExecute, OpenPetriNetFileCommandCanExecute);
            SavePetriNetCommand = new DelegateCommand(SavePetriNetCommandExecute, SavePetriNetCommandCanExecute);
            SavePetriNetUnderNewNameCommand = new DelegateCommand(SavePetriNetUnderNewNameCommandExecute, SavePetriNetUnderNewNameCommandCanExecute);
            OpenLastPetriNetFileCommand = new DelegateCommand<LastOpenedFile>(OpenLastPetriNetFileCommandExecute, OpenLastPetriNetFileCommandCanExecute);
            EditorViewModel = new EditorViewModel();
            //CurrentPnmlNet = new PnmlNet();
            LastOpenedFiles = GetLastOpenedFilesList();

        }

        #region Commands

        void OpenLastPetriNetFileCommandExecute(LastOpenedFile file)
        {
           OpenPetriNet(file.FileName);
        }

        void CreateNewPetriNetCommandExecute()
        {
            CurrentPnmlNet = new PnmlNet();
            IsSaved = false;
        }

        void OpenPetriNetFileCommandExecute()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|PNML (*.pnml)|*.pnml";
            openFileDialog.FilterIndex = 0;
            openFileDialog.DefaultExt = "xml";
            if(openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;
                OpenPetriNet(file);
            }
        }


        void SavePetriNetCommandExecute()
        {
            PetriNetXMLReader reader = new PetriNetXMLReader();

            if (CurrentFileName != null)
            {
                reader.SaveToXML(CurrentPnmlNet, CurrentFilePath);
                IsSaved = true;
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
                CurrentFileName = saveFileDialog.FileName;
                CurrentFilePath = CurrentFileName;
                IsSaved = true;
            }
        }

        #endregion

        #region CanExecute


        bool OpenLastPetriNetFileCommandCanExecute(LastOpenedFile file)
        {
            return true;
        }
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

        private void OpenPetriNet(string filename)
        {
            try
            {
                PetriNetXMLReader reader = new PetriNetXMLReader();
                CurrentPnmlNet = reader.ReadFromXML(filename);
                CurrentPnmlNet.PetriNet.InitDependencies();
                

                if (Settings.Default.LastOpenedFiles.Count > 0 && Settings.Default.LastOpenedFiles[0] == filename)
                {

                }
                else
                {
                    Settings.Default.LastOpenedFiles.Insert(0, filename);
                }

                Settings.Default.Save();
                LastOpenedFiles = GetLastOpenedFilesList();

                CurrentFileName = filename;
                CurrentFilePath = filename;
                IsSaved = true;
            }
            catch(Exception ex)
            {
                CurrentPnmlNet = null;
                MessageBox.Show("Petri Netz konnte nicht geöffnet werden", "Öffnen fehlgeschlagen", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private ObservableCollection<LastOpenedFile> GetLastOpenedFilesList()
        {
            var returnList = new ObservableCollection<LastOpenedFile>();
            var lastOpenedFiles = Settings.Default.LastOpenedFiles;
            if (lastOpenedFiles == null)
            {
                lastOpenedFiles = new StringCollection();
                Settings.Default.LastOpenedFiles = lastOpenedFiles;
                Settings.Default.Save();
            }
            foreach (var lastOpenedFile in lastOpenedFiles)
            {
                bool isAvailable = true;
                string isAvailableInfo = String.Empty;
                if (!File.Exists(lastOpenedFile))
                {
                    isAvailable = false;
                    isAvailableInfo = "Nicht gefunden";
                }
                returnList.Add(new LastOpenedFile(lastOpenedFile, isAvailableInfo, isAvailable));
            }

            return returnList;
        }
    }

    public class LastOpenedFile
    {
        public string FileName { get; set; }
        public string IsAvailableInfo { get; set; }
        public bool IsAvailable { get; set; }

        public LastOpenedFile(string filename, string availableInfo, bool isAvailable)
        {
            FileName = filename;
            IsAvailableInfo = availableInfo;
            IsAvailable = isAvailable;
        }

    }
}
