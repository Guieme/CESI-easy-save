using EasySaveApp.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasySaveApp.View
{
    /// <summary>
    /// Logique d'interaction pour ViewInputFileSize.xaml
    /// </summary>
    public partial class ViewInputFileSize : Page
    {
        public ViewInputFileSize()
        {
            InitializeComponent();
            InputFileSizeViewModel.GetInputFileSizeViewModel().InitView(fileSize);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            InputFileSizeViewModel.GetInputFileSizeViewModel().ConfirmSave(fileSize.Text);
            InputFileSize.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            InputFileSize.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
