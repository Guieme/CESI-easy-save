using EasySaveApp.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EasySaveApp.View
{
    /// <summary>
    /// Logique d'interaction pour ViewSettings.xaml
    /// </summary>
    public partial class ViewSettings : Page
    {
        public ViewSettings()
        {
            InitializeComponent();
        }
        /*private void LanguageButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            if (SettingsViewModel.GetSettingsViewModel().VerifyLanguage(srcButton.Name))
            {
                if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.Choice_ChangeLanguage))
                {
                    SettingsViewModel.GetSettingsViewModel().ChangeLanguage(srcButton.Name);
                }
                else
                    e.Source = new Uri("View/ViewSettings.xaml", UriKind.Relative);
            }
            else
            {
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_CurrentLanguage);
            }
        }*/

        private void ExtensionToCrypt_Click(object sender, RoutedEventArgs e)
        {
            Settings.Source = new Uri("ExtensionToCrypt.xaml", UriKind.Relative);
        }
        private void ExtensionLogFile_Click(object sender, RoutedEventArgs e)
        {
            Settings.Source = new Uri("ExtensionLogFile.xaml", UriKind.Relative);
        }
        private void Business_Click(object sender, RoutedEventArgs e)
        {
            Settings.Source = new Uri("ViewBusinessSoftware.xaml", UriKind.Relative);
        }

        private void PriorityFiles_Click(object sender, RoutedEventArgs e)
        {
            Settings.Source = new Uri("ViewPriorityFiles.xaml", UriKind.Relative);
        }

        private void EasterEgg(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image EasterEgg = e.Source as Image;
            SettingsViewModel.GetSettingsViewModel().ChangeLanguage(EasterEgg.Name);
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            if (SettingsViewModel.GetSettingsViewModel().VerifyLanguage(srcButton.Name))
            {
                if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.Choice_ChangeLanguage))
                {
                    SettingsViewModel.GetSettingsViewModel().ChangeLanguage(srcButton.Name);
                }
                else
                    e.Source = new Uri("View/ViewSettings.xaml", UriKind.Relative);
            }
            else
            {
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_CurrentLanguage);
            }
        }

        private void InputFileSize_Click(object sender, RoutedEventArgs e)
        {
            Settings.Source = new Uri("ViewInputFileSize.xaml", UriKind.Relative);
        }
    }
}
