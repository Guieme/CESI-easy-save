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
    /// Logique d'interaction pour ViewPriorityFiles.xaml
    /// </summary>
    public partial class ViewPriorityFiles : Page
    {
        public ViewPriorityFiles()
        {
            InitializeComponent();
            ShowPriority();
        }
        private void ShowPriority()
        {
            PriorityList.Children.Clear();
            foreach (var ext in PriorityFilesViewModel.GetPriorityFilesViewModel().GetPriorityFiles())
            {
                GroupItem ctn = new GroupItem();
                ctn.Name = ext.Substring(1);
                ctn.Width = 568;
                ctn.Margin = new Thickness(0, 10, 0, 0);

                Grid grid = new Grid();
                grid.Height = 50;
                grid.VerticalAlignment = VerticalAlignment.Top;

                Image bgExtention = new Image();
                bgExtention.Source = new BitmapImage(new Uri("\\Images\\PathBackgrounds.png", UriKind.Relative));

                TextBox PriorityName = new TextBox();
                PriorityName.IsReadOnly = true;
                PriorityName.TextAlignment = TextAlignment.Left;
                PriorityName.Margin = new Thickness(40, 0, 0, 0);
                PriorityName.TextWrapping = TextWrapping.NoWrap;
                PriorityName.Background = Brushes.Transparent;
                PriorityName.BorderThickness = new Thickness(0);
                PriorityName.VerticalContentAlignment = VerticalAlignment.Center;
                PriorityName.Foreground = Brushes.White;
                PriorityName.FontSize = 15;
                PriorityName.Text = ext.Substring(1);

                Image trashIcon = new Image();
                trashIcon.Source = new BitmapImage(new Uri("\\Images\\TrashIcon.png", UriKind.Relative));
                trashIcon.HorizontalAlignment = HorizontalAlignment.Right;
                trashIcon.Margin = new Thickness(0, 0, 20, 0);
                trashIcon.Width = 30;

                Button trashButton = new Button();
                trashButton.Name = "btnTrash_" + ext.Substring(1);
                trashButton.HorizontalAlignment = HorizontalAlignment.Right;
                trashButton.Margin = new Thickness(0, 0, 27, 0);
                trashButton.Width = 20;
                trashButton.Height = 25;
                trashButton.Background = Brushes.Transparent;
                trashButton.BorderBrush = Brushes.Transparent;
                trashButton.Click += RemovePriority;

                grid.Children.Add(bgExtention);
                grid.Children.Add(PriorityName);
                grid.Children.Add(trashIcon);
                grid.Children.Add(trashButton);

                ctn.Content = grid;

                PriorityList.Children.Add(ctn);
            }
        }

        private void BackPriorityFiles_Click(object sender, RoutedEventArgs e)
        {
            PriorityFilesFrame.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }
        private void RemovePriority(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            PriorityFilesViewModel.GetPriorityFilesViewModel().RemovePriorityFile(srcButton, PriorityList);
            ShowPriority();
        }
        private void AddPriority_Click(object sender, RoutedEventArgs e)
        {
            PriorityFilesViewModel.GetPriorityFilesViewModel().AddPriorityFile(txtNewPriority);
            ShowPriority();
        }
        private void SortPriority(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            PriorityFilesViewModel.GetPriorityFilesViewModel().SortPriorityFile(srcButton);
            ShowPriority();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text == "")
                falseSearch.Text = "Search";
            else
                falseSearch.Text = "";
            ShowPriority();
            PriorityFilesViewModel.GetPriorityFilesViewModel().DynamicSearch(Search.Text, PriorityList);
        }
        private void NewPriority_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNewPriority.Text == "")
                falseTxtNewPriority.Text = ".example";
            else
                falseTxtNewPriority.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PriorityFilesViewModel.GetPriorityFilesViewModel().RemoveAllPriorityFile();
            ShowPriority();

        }
    }
}
