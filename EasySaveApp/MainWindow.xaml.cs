using EasySaveApp.ViewModel;
using EasySaveApp.Networking;
using System;
using System.Threading;
using System.Windows;
using System.Diagnostics;

namespace EasySaveApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Communication.InitServer();
            new Thread(() => {  Communication.AcceptClient(); ReceiveEvent.ReceiveSomething(); }).Start();
            DataContext = MainViewModel.GetMainViewModel();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e) => Main.Source = new Uri("View/ViewHome.xaml", UriKind.Relative);

        private void BackUpsButton_Click(object sender, RoutedEventArgs e) => Main.Source = new Uri("View/ViewBackUps.xaml", UriKind.Relative);

        private void SettingsButton_Click(object sender, RoutedEventArgs e) => Main.Source = new Uri("View/ViewSettings.xaml", UriKind.Relative);
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!BackUpViewModel.VerVerifySameSourcePathStart(0))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_SaveInProgress); //Error_SaveInProgess
            }

            else if(UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.Choice_Confirm))
            {
                Communication.sendSemaphore.WaitOne();
                Communication.SendData("Exit");
                Communication.sendSemaphore.Release();

                Process.GetCurrentProcess().Kill();
            }
        }

        
    }
}
