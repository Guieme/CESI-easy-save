using EasySaveApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EasySaveApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var langCode = EasySaveApp.Properties.Settings.Default.languageCode;                    // Store the default settings for languageCode into var langCode
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode); // Initialize the language app with langCode
            //delete the startupuri tag from your app.xaml
            base.OnStartup(e);
            //this MainViewModel from your ViewModel project
        }
    }
}
