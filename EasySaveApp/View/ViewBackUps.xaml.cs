using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySaveApp.ViewModel;

namespace EasySaveApp.View
{
    /// <summary>
    /// Logique d'interaction pour ViewBackUps.xaml
    /// </summary>
    public partial class ViewBackUps : Page
    {
        public ViewBackUps()
        {
            InitializeComponent();
            BackUpViewModel.GetBackUpViewModel();
            BackUpViewModel.BackupList = BackupList;
            ShowSaves();
        }

        private void ShowSaves()
        {
            BackupList.Children.Clear();
            var saveList = BackUpViewModel.GetBackUpViewModel().GetSaveList();
            if (saveList != null)
            {
                foreach (var save in saveList)
                {
                    GroupItem ctn = new GroupItem();
                    ctn.VerticalAlignment = VerticalAlignment.Top;
                    ctn.Name = Convert.ToString(save.Name);

                    Grid grid = new Grid();
                    grid.Height = 50;
                    grid.VerticalAlignment = VerticalAlignment.Top;
                    ColumnDefinition col1 = new ColumnDefinition();
                    col1.Width = new GridLength(130);
                    ColumnDefinition col2 = new ColumnDefinition();
                    col2.Width = new GridLength(269);
                    ColumnDefinition col3 = new ColumnDefinition();
                    col3.Width = new GridLength(100);
                    ColumnDefinition col4 = new ColumnDefinition();
                    col4.Width = new GridLength(50);
                    grid.ColumnDefinitions.Add(col1);
                    grid.ColumnDefinitions.Add(col2);
                    grid.ColumnDefinitions.Add(col3);
                    grid.ColumnDefinitions.Add(col4);

                    // ======= Global Items ======= //

                    // => ProgressBar
                    ProgressBar progressBars = new ProgressBar();
                    progressBars.Name = "Progress_" + save.Name;
                    progressBars.Visibility = Visibility.Hidden;
                    progressBars.VerticalAlignment = VerticalAlignment.Center;
                    progressBars.HorizontalAlignment = HorizontalAlignment.Center;
                    progressBars.Width = 300;
                    progressBars.Height = 10;
                    progressBars.ValueChanged += ProgressBars_ValueChanged;
                    //Gradient Colors
                    var startColor = (Color)ColorConverter.ConvertFromString("#FFB90C72");
                    var startGradienStop = new GradientStop();
                    startGradienStop.Color = startColor;
                    var endColor = (Color)ColorConverter.ConvertFromString("#FFDC13B8");
                    var endGradienStop = new GradientStop();
                    endGradienStop.Color = endColor;
                    endGradienStop.Offset = 1;
                    var gradStopCollection = new GradientStopCollection();
                    gradStopCollection.Add(endGradienStop);
                    gradStopCollection.Add(startGradienStop);
                    progressBars.Foreground = new LinearGradientBrush(gradStopCollection, new Point(0.5, 0), new Point(0.5, 1));
                    Grid.SetColumn(progressBars, 1);
                    Grid.SetColumnSpan(progressBars, 2);

                    // => Global BackGround
                    Image imgBackground = new Image();
                    Grid.SetColumn(imgBackground, 0);
                    Grid.SetColumnSpan(imgBackground, 4);
                    imgBackground.Source = new BitmapImage(new Uri("\\Images\\PathBackGrounds.png", UriKind.Relative));
                    imgBackground.VerticalAlignment = VerticalAlignment.Center;

                    // ======= Column 0 ======= //

                    // => Save name textBox 
                    TextBox txtNameBackUp = new TextBox();
                    Grid.SetColumn(txtNameBackUp, 0);
                    txtNameBackUp.Text = save.Name;
                    txtNameBackUp.IsReadOnly = true;
                    txtNameBackUp.VerticalAlignment = VerticalAlignment.Center;
                    txtNameBackUp.HorizontalAlignment = HorizontalAlignment.Center;
                    txtNameBackUp.Foreground = Brushes.White;
                    txtNameBackUp.Background = Brushes.Transparent;
                    txtNameBackUp.BorderBrush = Brushes.Transparent;
                    txtNameBackUp.FontSize = 16;
                    txtNameBackUp.FontWeight = FontWeights.Bold;


                    // ======= Column 1 ======= //

                    // => Creating Target and Source TextBox Title
                    TextBox txtTargetPathTitle = new TextBox
                    {
                        Text = Properties.Langs.Lang.VCBU_TP,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Foreground = Brushes.White,
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        IsReadOnly = true,
                        Margin = new Thickness(20, 0, 0, 7),
                        FontWeight = FontWeights.Bold,
                        FontSize = 10
                        
                    };
                    TextBox txtSourcePathTitle = new TextBox
                    {
                        Text = Properties.Langs.Lang.VCBU_SP,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Foreground = Brushes.White,
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        IsReadOnly = true,
                        Margin = new Thickness(20, 7, 0, 0),
                        FontSize = 10,
                        FontWeight = FontWeights.Bold
                    };
                    Grid.SetColumn(txtSourcePathTitle, 1);
                    Grid.SetColumn(txtTargetPathTitle, 1);

                    // => Creating 2 Folders Icons Images
                    Image imgSourceFolder = new Image
                    {
                        Source = new BitmapImage(new Uri("\\Images\\FolderIcon.png", UriKind.Relative)),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(84, 5, 0, 0),
                        Height = 20
                    };
                    Image imgTargetFolder = new Image
                    {
                        Source = new BitmapImage(new Uri("\\Images\\FolderIcon.png", UriKind.Relative)),
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(84, 0, 0, 5),
                        Height = 20
                    };
                    Grid.SetColumn(imgTargetFolder, 1);
                    Grid.SetColumn(imgSourceFolder, 1);

                    //=> Creating Buttons to open FolderDialog
                    Button btnSourceBrowse = new Button
                    {
                        Name = "SelectSourceButton_" + save.Name,
                        Opacity = 0,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(84, 5, 0, 0),
                        Height = 20,
                        Width = 20,
                    };
                    Button btnTargetBrowse = new Button
                    {
                        Name = "SelectTargetButton_" + save.Name,
                        Opacity = 0,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(84, 0, 0, 5),
                        Height = 20,
                        Width = 20,
                    };
                    btnSourceBrowse.Click += BtnFolderBrowse_Click;
                    btnTargetBrowse.Click += BtnFolderBrowse_Click;
                    Grid.SetColumn(btnSourceBrowse, 1);
                    Grid.SetColumn(btnTargetBrowse, 1);

                    // => Creating TextBoxes to show Path selected

                    TextBox txtSourcePathSelected = new TextBox
                    {
                        Width = 150,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Text = save.Source,
                        Foreground = Brushes.White,
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        IsReadOnly = true,
                        Margin = new Thickness(109, 7, 0, 0),
                        FontSize = 10,
                        FontWeight = FontWeights.Bold
                    };
                    TextBox txtTargetPathSelected = new TextBox
                    {
                        Width = 150,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Text = save.Target,
                        Foreground = Brushes.White,
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        IsReadOnly = true,
                        Margin = new Thickness(109, 0, 0, 7),
                        FontSize = 10,
                        FontWeight = FontWeights.Bold
                    };
                    Grid.SetColumn(txtTargetPathSelected, 1);
                    Grid.SetColumn(txtSourcePathSelected, 1);

                    // ======= Column 2 ======= //

                    //=> Creating Images for RadioButtons
                    RadioButton radioBtnCompleteType = new RadioButton
                    {
                        Name = "Complete_" + save.Name,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(3, 8, 0, 0),
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        Foreground = Brushes.Transparent,
                        Height = 20,
                        Opacity = 0,
                        Width = 20,
                        IsChecked = BackUpViewModel.GetBackUpViewModel().IsCompleteType(save),
                    };
                    RadioButton radioBtnDifferentialType = new RadioButton
                    {
                        Name = "Differential_" + save.Name,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(3, 0, 0, 2),
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        Foreground = Brushes.Transparent,
                        Opacity = 0,
                        Height = 20,
                        Width = 20,
                        IsChecked = !BackUpViewModel.GetBackUpViewModel().IsCompleteType(save)
                    };
                    radioBtnCompleteType.Click += RadioBtnCompleteType_Click;
                    radioBtnDifferentialType.Click += RadioBtnDifferentialType_Click;
                    Grid.SetColumn(radioBtnCompleteType, 2);
                    Grid.SetColumn(radioBtnDifferentialType, 2);

                    // => Create Image for RadioButtons
                    Image imgRadBtnComplete = new Image
                    {
                        Source = BackUpViewModel.GetBackUpViewModel().GetActualRadioButton(radioBtnCompleteType),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(0, 5, 0, 0),
                        Height = 20,
                        Width = 20
                    };
                    Image imgRadBtnDifferential = new Image
                    {
                        Source = BackUpViewModel.GetBackUpViewModel().GetActualRadioButton(radioBtnDifferentialType),
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(0, 0, 0, 5),
                        Height = 20,
                        Width = 20
                    };
                    Grid.SetColumn(imgRadBtnComplete, 2);
                    Grid.SetColumn(imgRadBtnDifferential, 2);

                    // => Title text for RadioButtons
                    TextBox txtCompleteTitle = new TextBox
                    {
                        Text = Properties.Langs.Lang.VCBU_Complete,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(20, 7, 0, 0),
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        Foreground = Brushes.White,
                        IsReadOnly = true,
                        FontSize = 10
                    };
                    TextBox txtDifferentialTitle = new TextBox
                    {
                        Text = Properties.Langs.Lang.VCBU_Diff,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(20, 0, 0, 7),
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        Foreground = Brushes.White,
                        IsReadOnly = true,
                        FontSize = 10
                    };
                    Grid.SetColumn(txtCompleteTitle, 2);
                    Grid.SetColumn(txtDifferentialTitle, 2);

                    // ======= Column 3 ======= //

                    // => Delete Image for Button
                    Image imgDeleteButton = new Image();
                    Grid.SetColumn(imgDeleteButton, 3);
                    imgDeleteButton.Height = 20;
                    imgDeleteButton.HorizontalAlignment = HorizontalAlignment.Right;
                    imgDeleteButton.Margin = new Thickness(0, 0, 10, 0);
                    imgDeleteButton.Source = new BitmapImage(new Uri("\\Images\\TrashIcon.png", UriKind.Relative));

                    // => Start Image for Button
                    Image imgStartButton = new Image();
                    Grid.SetColumn(imgStartButton, 3);
                    imgStartButton.Height = 20;
                    imgStartButton.HorizontalAlignment = HorizontalAlignment.Right;
                    imgStartButton.Margin = new Thickness(0, 0, 30, 0);
                    imgStartButton.Source = new BitmapImage(new Uri("\\Images\\StartIcon.png", UriKind.Relative));

                    //=> Play / Pause Image for Button
                    Image imgChangeStateButton = new Image();
                    Grid.SetColumn(imgChangeStateButton, 3);
                    imgChangeStateButton.Height = 20;
                    imgChangeStateButton.HorizontalAlignment = HorizontalAlignment.Right;
                    imgChangeStateButton.Margin = new Thickness(0, 0, 30, 0);
                    imgChangeStateButton.Source = new BitmapImage(new Uri("\\Images\\PauseIcon.png", UriKind.Relative));
                    imgChangeStateButton.Visibility = Visibility.Hidden;

                    // => Stop Image for Button
                    Image imgStopButton = new Image();
                    Grid.SetColumn(imgStopButton, 3);
                    imgStopButton.Height = 20;
                    imgStopButton.HorizontalAlignment = HorizontalAlignment.Right;
                    imgStopButton.Margin = new Thickness(0, 0, 10, 0);
                    imgStopButton.Source = new BitmapImage(new Uri("\\Images\\StopIcon.png", UriKind.Relative));
                    imgStopButton.Visibility = Visibility.Hidden;

                    // => Start Button
                    Button rButtonStart = new Button();
                    Grid.SetColumn(rButtonStart, 3);
                    rButtonStart.Height = 20;
                    rButtonStart.Width = 20;
                    rButtonStart.Opacity = 0;
                    rButtonStart.HorizontalAlignment = HorizontalAlignment.Right;
                    rButtonStart.Margin = new Thickness(0, 0, 30, 0);
                    rButtonStart.Name = "Start_" + save.Name;
                    rButtonStart.Click += StartBackUps_Click;

                    // => Delete Button
                    Button rButtonDelete = new Button();
                    Grid.SetColumn(rButtonDelete, 3);
                    rButtonDelete.Height = 20;
                    rButtonDelete.Width = 20;
                    rButtonDelete.Opacity = 0;
                    rButtonDelete.HorizontalAlignment = HorizontalAlignment.Right;
                    rButtonDelete.Margin = new Thickness(0, 0, 10, 0);
                    rButtonDelete.Name = "Delete_" + save.Name;
                    rButtonDelete.Click += DeleteBackUps_Click;

                    // => Stop Button
                    Button rButtonStop = new Button();
                    Grid.SetColumn(rButtonStop, 3);
                    rButtonStop.Height = 20;
                    rButtonStop.Width = 20;
                    rButtonStop.Opacity = 0;
                    rButtonStop.HorizontalAlignment = HorizontalAlignment.Right;
                    rButtonStop.Margin = new Thickness(0, 0, 10, 0);
                    rButtonStop.Name = "Stop_" + save.Name;
                    rButtonStop.Click += StopBackUps_Click;
                    rButtonStop.Visibility = Visibility.Hidden;

                    // => Pause Button
                    Button rButtonPause = new Button();
                    Grid.SetColumn(rButtonPause, 3);
                    rButtonPause.Height = 20;
                    rButtonPause.Width = 20;
                    rButtonPause.Opacity = 0;
                    rButtonPause.HorizontalAlignment = HorizontalAlignment.Right;
                    rButtonPause.Margin = new Thickness(0, 0, 30, 0);
                    rButtonPause.Name = "Pause_" + save.Name;
                    rButtonPause.Click += PauseBackUps_Click;
                    rButtonPause.Visibility = Visibility.Hidden;

                    // => Play Button
                    Button rButtonPlay = new Button();
                    Grid.SetColumn(rButtonPlay, 3);
                    rButtonPlay.Height = 20;
                    rButtonPlay.Width = 20;
                    rButtonPlay.Opacity = 0;
                    rButtonPlay.HorizontalAlignment = HorizontalAlignment.Right;
                    rButtonPlay.Margin = new Thickness(0, 0, 30, 0);
                    rButtonPlay.Name = "Play_" + save.Name;
                    rButtonPlay.Click += PlayBackUps_Click;
                    rButtonPlay.Visibility = Visibility.Hidden;


                    // DOM creation

                    // => Global
                    grid.Children.Add(imgBackground);
                    grid.Children.Add(progressBars);
                    // Column 1
                    grid.Children.Add(txtNameBackUp);
                    // Column 3
                    grid.Children.Add(imgStartButton);
                    grid.Children.Add(imgDeleteButton);
                    grid.Children.Add(imgStopButton);
                    grid.Children.Add(imgChangeStateButton);
                    grid.Children.Add(rButtonStop);
                    grid.Children.Add(rButtonPause);
                    grid.Children.Add(rButtonPlay);
                    grid.Children.Add(rButtonStart);
                    grid.Children.Add(rButtonDelete);
                    // Column 2
                    grid.Children.Add(txtCompleteTitle);
                    grid.Children.Add(txtDifferentialTitle);
                    grid.Children.Add(imgRadBtnComplete);
                    grid.Children.Add(imgRadBtnDifferential);
                    grid.Children.Add(radioBtnCompleteType);
                    grid.Children.Add(radioBtnDifferentialType);
                    // Column 2
                    grid.Children.Add(txtSourcePathTitle);
                    grid.Children.Add(txtTargetPathTitle);
                    grid.Children.Add(txtSourcePathSelected);
                    grid.Children.Add(txtTargetPathSelected);
                    grid.Children.Add(imgSourceFolder);
                    grid.Children.Add(imgTargetFolder);
                    grid.Children.Add(btnSourceBrowse);
                    grid.Children.Add(btnTargetBrowse);

                    ctn.Content = grid;
                    BackupList.Children.Add(ctn);
                }
            }
        }

        private void BtnFolderBrowse_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            string saveName = srcButton.Name[(19)..];
            BackUpViewModel.GetBackUpViewModel().FolderDialog(srcButton, saveName);
        }
        private void RadioBtnCompleteType_Click(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            string saveName = srcButton.Name[(9)..];
            BackUpViewModel.GetBackUpViewModel().ChangeBackUpType(saveName, "Complete");
        }
        private void RadioBtnDifferentialType_Click(object sender, RoutedEventArgs e)
        {
            RadioButton srcButton = e.Source as RadioButton;
            string saveName = srcButton.Name[(13)..];
            BackUpViewModel.GetBackUpViewModel().ChangeBackUpType(saveName, "Differential");
        }
        private void ProgressBars_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ProgressBar srcProgressBar = e.Source as ProgressBar;
            if (srcProgressBar.Value == 100)
            {
                string saveName = srcProgressBar.Name[(9)..];
                BackUpViewModel.GetBackUpViewModel().StoppedBackup(saveName);

            }
        }

        // Button Events
        private void AddBackUps_Click(object sender, RoutedEventArgs e)
        {
            BackUps.Source = new Uri("ViewCreateBackUps.xaml", UriKind.Relative);
        }
        private void DeleteBackUps_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            string saveName = srcButton.Name[(7)..];
            BackUpViewModel.GetBackUpViewModel().DeleteBackup(saveName, false);
        }
        private void StartBackUps_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            string saveName = srcButton.Name[(6)..];

            if (BackUpViewModel.VerVerifySameSourcePathStart(1, saveName))
            {
                BackUpViewModel.GetBackUpViewModel().ActiveBackUp(saveName);
                BackUpViewModel.GetBackUpViewModel().StartBackup(saveName, false);
            }
            else
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_SameSourcePath); //Error Same SP
            }
        }
        private void StartAllBackUps_Click(object sender, RoutedEventArgs e) 
        { 
            BackUpViewModel.GetBackUpViewModel().StartAllBackup(false);
        }
        private void StopBackUps_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            string saveName = srcButton.Name[(5)..];

            if(BackUpViewModel.VerVerifySameSourcePathStart(2, saveName))
            {
                BackUpViewModel.GetBackUpViewModel().StoppedBackup(saveName);
                BackUpViewModel.GetBackUpViewModel().StopBackUp(saveName);
                UserErrorManagement.InformationPopUp(Properties.Langs.Lang.Error);
            }
            else
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_Critical); //Error_critical
            }
        }
        private void PauseBackUps_Click(object sender, RoutedEventArgs e)
        {
            Button srcButton = e.Source as Button;
            string saveName = srcButton.Name[(6)..];

            if (BackUpViewModel.VerVerifySameSourcePathStart(2, saveName))
            {
                BackUpViewModel.GetBackUpViewModel().PausedBackup(saveName);
                BackUpViewModel.GetBackUpViewModel().ChangeState(saveName, "Pause", false);
            }
            else
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_Critical); //Error_critical
            }
        }
        private void PlayBackUps_Click(object sender, RoutedEventArgs e)
        {
            // Need to add a pop up error if the selected save has a source path taht is already used by another save save in progress
            Button srcButton = e.Source as Button;
            string saveName = srcButton.Name[(5)..];

            if (BackUpViewModel.VerVerifySameSourcePathStart(1, saveName))
            {
                BackUpViewModel.GetBackUpViewModel().PlayedBackup(saveName);
                BackUpViewModel.GetBackUpViewModel().ChangeState(saveName, "Play", false);
            }
            else
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_SameSourcePath); //Error Same SP
            }

        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchSave.Text == "")
                falseSearch.Text = "Search";
            else
                falseSearch.Text = "";
            ShowSaves();
            BackUpViewModel.GetBackUpViewModel().DynamicSearch(SearchSave.Text, BackupList);
        }

        private void BackupList_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (BackupList.Visibility == Visibility.Visible)
                ShowSaves();
        }
    }
}
