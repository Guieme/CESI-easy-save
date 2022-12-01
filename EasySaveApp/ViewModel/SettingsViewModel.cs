using EasySaveApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;

namespace EasySaveApp.ViewModel
{
    public class SettingsViewModel
    {
        private static SettingsViewModel Instance;
        private Settings settings;
        public static SettingsViewModel GetSettingsViewModel()
        {
            if (Instance == null)
                Instance = new SettingsViewModel();
            return Instance;
        }
        private SettingsViewModel() { settings = Settings.GetSettings(); }
        
        public void ChangeLanguage(string Language)
        {
            Properties.Settings.Default.languageCode = Language;    //Set languageCode Parameter to "en"
            Properties.Settings.Default.Save();                 //Save the changement

            var langCode = EasySaveApp.Properties.Settings.Default.languageCode;                       //Store languageCode into langCode
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);    //Switch the currentUICulture to thenew globalization with newest parameter set

            Process.Start(Process.GetCurrentProcess().MainModule.FileName);     //Get the current Process
            Process.GetCurrentProcess().Kill();
        }

        public bool VerifyLanguage(string Language)
        {
            if (Properties.Settings.Default.languageCode == Language)
            {
                return false;
            }
            else
                return true;
        }
    }
}
