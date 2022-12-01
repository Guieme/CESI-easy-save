using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using EasySaveApp_Client.Model;
using EasySaveApp_Client.ViewModel;
using Microsoft.Win32;
using static System.Environment;

namespace EasySaveApp_Client.View
{
    /// <summary>
    /// Logique d'interaction pour ViewCreateBackUps.xaml
    /// </summary>
    public partial class ViewCreateBackUps : Page
    { 
        public ViewCreateBackUps()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ConfigBackUps.Source = new Uri("ViewBackUps.xaml", UriKind.Relative);
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (CreateBackUpViewModel.GetCreateBackUpViewModel().ConfirmSave(CompleteRadioButton, DifférentialRadioButton, targetPathSave, sourcePathSave, txtSaveName))
            {
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Info_SaveCreated, txtSaveName.Text, true);
                ConfigBackUps.Source = new Uri("ViewBackUps.xaml", UriKind.Relative);
            }
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            CreateBackUpViewModel.GetCreateBackUpViewModel().FolderDialog(srcButton, sourcePathSave, targetPathSave);
        }
        private void CheckedMode(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            CreateBackUpViewModel.GetCreateBackUpViewModel().CheckedMode(imgCompleteButton, imgDifferentialButton, srcButton);
        }
    }
}
