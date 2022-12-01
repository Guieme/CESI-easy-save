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
    /// Logique d'interaction pour ViewBusinessSoftware.xaml
    /// </summary>
    public partial class ViewBusinessSoftware : Page
    {
        public ViewBusinessSoftware()
        {
            InitializeComponent();
            ShowBusiness();
        }
        private void ShowBusiness()
        {
            BusinessSoftList.Children.Clear();
            foreach (var ext in BusinessSoftwareViewModel.GetBusinessSoftwareViewModel().GetBusiness())
            {
                GroupItem ctn = new GroupItem();
                ctn.Name = ext.Replace(".","_");
                ctn.Width = 568;
                ctn.Margin = new Thickness(0, 10, 0, 0);

                Grid grid = new Grid();
                grid.Height = 50;
                grid.VerticalAlignment = VerticalAlignment.Top;

                Image bgExtention = new Image();
                bgExtention.Source = new BitmapImage(new Uri("\\Images\\PathBackgrounds.png", UriKind.Relative));

                TextBox businessName = new TextBox();
                businessName.IsReadOnly = true;
                businessName.TextAlignment = TextAlignment.Left;
                businessName.Margin = new Thickness(40, 0, 0, 0);
                businessName.TextWrapping = TextWrapping.NoWrap;
                businessName.Background = Brushes.Transparent;
                businessName.BorderThickness = new Thickness(0);
                businessName.VerticalContentAlignment = VerticalAlignment.Center;
                businessName.Foreground = Brushes.White;
                businessName.FontSize = 15;
                businessName.Text = ext;

                Image trashIcon = new Image();
                trashIcon.Source = new BitmapImage(new Uri("\\Images\\TrashIcon.png", UriKind.Relative));
                trashIcon.HorizontalAlignment = HorizontalAlignment.Right;
                trashIcon.Margin = new Thickness(0, 0, 20, 0);
                trashIcon.Width = 30;

                Button trashButton = new Button();
                trashButton.Name = "btnTrash_" + ext.Replace(".", "_");
                trashButton.HorizontalAlignment = HorizontalAlignment.Right;
                trashButton.Margin = new Thickness(0, 0, 27, 0);
                trashButton.Width = 20;
                trashButton.Height = 25;
                trashButton.Background = Brushes.Transparent;
                trashButton.BorderBrush = Brushes.Transparent;
                trashButton.Click += RemoveBusiness;

                grid.Children.Add(bgExtention);
                grid.Children.Add(businessName);
                grid.Children.Add(trashIcon);
                grid.Children.Add(trashButton);

                ctn.Content = grid;

                BusinessSoftList.Children.Add(ctn);
            }
        }
        private void BackBusinessSoftware_Click(object sender, RoutedEventArgs e)
        {
            BusinessSoftwareFrame.Source = new Uri("ViewSettings.xaml", UriKind.Relative);
        }
        private void RemoveBusiness(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            BusinessSoftwareViewModel.GetBusinessSoftwareViewModel().RemoveBusinessSoftWare(srcButton, BusinessSoftList);
            ShowBusiness();
        }
        private void AddBusiness_Click(object sender, RoutedEventArgs e)
        {
            BusinessSoftwareViewModel.GetBusinessSoftwareViewModel().AddBusinessSoftWare(txtNewSoftware);
            ShowBusiness();
        }
        private void SortBusiness(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            BusinessSoftwareViewModel.GetBusinessSoftwareViewModel().SortBusinessSoftWareList(srcButton);
            ShowBusiness();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text == "")
                falseSearch.Text = "Search";
            else
                falseSearch.Text = "";
            ShowBusiness();
            BusinessSoftwareViewModel.GetBusinessSoftwareViewModel().DynamicSearch(Search.Text, BusinessSoftList);
        }
        private void NewSoftware_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNewSoftware.Text == "")
                falseTxtNewSoftware.Text = "example.exe";
            else
                falseTxtNewSoftware.Text = "";
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            BusinessSoftwareViewModel.GetBusinessSoftwareViewModel().RemoveAllBusiness();
            ShowBusiness();
        }
    }
}
