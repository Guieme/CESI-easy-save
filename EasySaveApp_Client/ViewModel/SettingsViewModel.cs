using EasySaveApp_Client.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;

namespace EasySaveApp_Client.ViewModel
{
    public class SettingsViewModel
    {
        private static SettingsViewModel Instance;
        public static SettingsViewModel GetSettingsViewModel()
        {
            if (Instance == null)
                Instance = new SettingsViewModel();
            return Instance;
        }
        private SettingsViewModel() {}
        
        public void ChangeLanguage(string Language)
        {
            Properties.Settings.Default.languageCode = Language;    //Set languageCode Parameter to "en"
            Properties.Settings.Default.Save();                 //Save the changement

            var langCode = EasySaveApp_Client.Properties.Settings.Default.languageCode;                       //Store languageCode into langCode
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);    //Switch the currentUICulture to thenew globalization with newest parameter set

            Process.Start(Process.GetCurrentProcess().MainModule.FileName);     //Get the current Process
            Application.Current.Shutdown();
        }
    }
}
