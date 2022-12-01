using EasySaveApp_Client.ViewModel;
using EasySaveApp_Client.Networking;
using System;
using System.Windows;
using System.Threading;

namespace EasySaveApp_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Communication.Connecting();
            new Thread(() => { ReceiveEvent.ReceiveSomething(); }).Start();
            DataContext = MainViewModel.GetMainViewModel();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e) => Main.Source = new Uri("View/ViewHome.xaml", UriKind.Relative);

        private void BackUpsButton_Click(object sender, RoutedEventArgs e) => Main.Source = new Uri("View/ViewBackUps.xaml", UriKind.Relative);

        private void ExitButton_Click(object sender, RoutedEventArgs e) 
        {
            Communication.SendingSemaphore.WaitOne();
            Communication.SendData("Exit");
            Communication.SendingSemaphore.Release();
            Application.Current.Shutdown(); 
        }
    }
}
