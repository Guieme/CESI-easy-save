using EasySaveApp_Client.Core;
using EasySaveApp_Client.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveApp_Client.ViewModel
{
    public class MainViewModel : ObservableObject
    {
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
        private MainViewModel() { }// => BackUpViewModel.GetBackUpViewModel().GetSaveList();
        public static MainViewModel GetMainViewModel()
        {
            if(Instance == null)
                Instance = new MainViewModel();
            return Instance;
        }
    }
}
