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
    /// Logique d'interaction pour ExtensionToCrypt.xaml
    /// </summary>
    public partial class ExtensionToCrypt : Page
    {
        public ExtensionToCrypt()
        {
            InitializeComponent();
            ShowExtension();
        }

        private void ShowExtension()
        {
            ExtentionList.Children.Clear();
            foreach (var ext in ExtensionToCryptViewModel.GetExtensionToCryptViewModel().GetExtensionsToEncrypt())
            {
                GroupItem ctn = new GroupItem();
                ctn.Name = ext.Substring(1);
                ctn.Width = 568;
                ctn.Margin = new Thickness(0,10,0,0);

                Grid grid = new Grid();
                grid.Height = 50;
                grid.VerticalAlignment = VerticalAlignment.Top;

                Image bgExtention = new Image();
                bgExtention.Source = new BitmapImage(new Uri("\\Images\\PathBackgrounds.png", UriKind.Relative));

                TextBox extensionName = new TextBox();
                extensionName.IsReadOnly = true;
                extensionName.TextAlignment = TextAlignment.Left;
                extensionName.Margin = new Thickness(40,0,0,0);
                extensionName.TextWrapping = TextWrapping.NoWrap;
                extensionName.Background = Brushes.Transparent;
                extensionName.BorderThickness = new Thickness(0);
                extensionName.VerticalContentAlignment = VerticalAlignment.Center;
                extensionName.Foreground = Brushes.White;
                extensionName.FontSize = 15;
                extensionName.Text = ext.Substring(1);

                Image trashIcon = new Image();
                trashIcon.Source = new BitmapImage(new Uri("\\Images\\TrashIcon.png", UriKind.Relative));
                trashIcon.HorizontalAlignment = HorizontalAlignment.Right;
                trashIcon.Margin = new Thickness(0,0,20,0);
                trashIcon.Width = 30;

                Button trashButton = new Button();
                trashButton.Name = "btnTrash_" + ext.Substring(1);
                trashButton.HorizontalAlignment = HorizontalAlignment.Right;
                trashButton.Margin = new Thickness(0,0,27,0);
                trashButton.Width = 20;
                trashButton.Height = 25;
                trashButton.Background = Brushes.Transparent;
                trashButton.BorderBrush = Brushes.Transparent;
                trashButton.Click += RemoveExtension;

                grid.Children.Add(bgExtention);
                grid.Children.Add(extensionName);
                grid.Children.Add(trashIcon);
                grid.Children.Add(trashButton);
                
                ctn.Content = grid;

                ExtentionList.Children.Add(ctn);
            }
        }
        private void BackEncryption_Click(object sender, RoutedEventArgs e)
        {
            ExtensionToCryptFrame.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }

        private void RemoveExtension(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            ExtensionToCryptViewModel.GetExtensionToCryptViewModel().RemoveExtension(srcButton, ExtentionList);
            ShowExtension();
        }
        private void AddExtension_Click(object sender, RoutedEventArgs e)
        {
            ExtensionToCryptViewModel.GetExtensionToCryptViewModel().AddExtension(txtNewExtention);
            ShowExtension();
        }
        private void SortExtension(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            ExtensionToCryptViewModel.GetExtensionToCryptViewModel().SortExtensionList(srcButton);
            ShowExtension();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text == "")
                falseSearch.Text = "Search";
            else
                falseSearch.Text = "";
            ShowExtension();
            ExtensionToCryptViewModel.GetExtensionToCryptViewModel().DynamicSearch(Search.Text, ExtentionList);
        }
        private void NewExtension_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNewExtention.Text == "")
                falseTxtNewExtention.Text = ".example";
            else
                falseTxtNewExtention.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ExtensionToCryptViewModel.GetExtensionToCryptViewModel().RemoveAllExtension();
            ShowExtension();
        }
    }
}
