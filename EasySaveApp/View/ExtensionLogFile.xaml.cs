using EasySaveApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasySaveApp.View
{
    /// <summary>
    /// Logique d'interaction pour ExtensionLogFile.xaml
    /// </summary>
    public partial class ExtensionLogFile : Page
    {
        public ExtensionLogFile()
        {
            InitializeComponent();
            ExtensionLogFileViewModel.GetExtensionLogFileViewModel().InitViewButtons(XmlRadioButton, JsonRadioButton);
        }

        private void ConfirmExtensionLogFile_Click(object sender, RoutedEventArgs e)
        {

            ExtensionLogFileViewModel.GetExtensionLogFileViewModel().ConfirmExtensionLogFile(XmlRadioButton, JsonRadioButton);
            //UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Error);
            ExtensionLogFileFrame.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }
        private void BackExtensionLogFile_Click(object sender, RoutedEventArgs e)
        {
            ExtensionLogFileFrame.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }
        private void CheckedExtension(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            ExtensionLogFileViewModel.GetExtensionLogFileViewModel().CheckedExtension(imgXmlRadioButton, imgJsonRadioButton, srcButton);
        }
    }
}
