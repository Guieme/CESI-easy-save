using EasySaveApp.Core;
using EasySaveApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveApp.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public List<Save> saves;
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private static MainViewModel Instance;
        private MainViewModel()
        {
            BackupManagment.GetBackupManagment().InitSoft();
            saves = new List<Save>();
            saves = BackupManagment.GetBackupManagment().RestoreBackup(this);
            BackupManagment.GetBackupManagment().RestoreExtensionsToCrypt();
            BackupManagment.GetBackupManagment().RestoreBusinessSoft();
            BackupManagment.GetBackupManagment().RestorePriorityFiles();
            BackupManagment.GetBackupManagment().RestoreBigFile();
        }
        public static MainViewModel GetMainViewModel()
        {
            if(Instance == null)
                Instance = new MainViewModel();
            return Instance;
        }
    }
}
