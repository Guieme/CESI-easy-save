using System;
using System.Collections.Generic;
using System.Text;
using EasySaveApp_Client.View;
using EasySaveApp_Client.Model;
using EasySaveApp_Client.Networking;
using System.Threading;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EasySaveApp_Client.ViewModel
{
    public class BackUpViewModel
    {
        public static StackPanel BackupList { get; set; }
        private List<Save> Saves;
        public List<Save> GetSaves() { return Saves; }
        public void SetSaves(List<Save> list) 
        { 
            Saves = list;
            if(BackupList != null) 
            {
                BackupList.Visibility = Visibility.Hidden;
                BackupList.Visibility = Visibility.Visible;
            }
        }

        // Singleton Pattern
        private static BackUpViewModel Instance { get; set; }
        public static BackUpViewModel GetBackUpViewModel()
        {
            if (Instance == null)
                Instance = new BackUpViewModel();

            return Instance;
        }
        private BackUpViewModel() 
        {
            Communication.SendingSemaphore.WaitOne();
            Communication.SendData("Initialisation");
            Communication.SendingSemaphore.Release();
        }

        // View Modifications
        private GroupItem GetCurrentSaveGrid(string saveName)
        {
            GroupItem groupItem = null;
            foreach (var child in BackupList.Children)
            {
                GroupItem groupitem = (GroupItem)child;
                if (groupitem.Name == saveName)
                    groupItem = groupitem;
                else
                    continue;
            }
            return groupItem;
        }
        public void ActiveBackUp(string saveName)
        {
            Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;

            ProgressBar progressBar = (ProgressBar)grid.Children[1];
            Image imgStartButton = (Image)grid.Children[3];
            Image imgDeleteButton = (Image)grid.Children[4];
            Image imgStopButton = (Image)grid.Children[5];
            Image imgChangeStateButton = (Image)grid.Children[6];
            Button rButtonStop = (Button)grid.Children[7];
            Button rButtonPause = (Button)grid.Children[8];
            Button rButtonStart = (Button)grid.Children[10];
            Button rButtonDelete = (Button)grid.Children[11];
            TextBox txtCompleteTitle = (TextBox)grid.Children[12];
            TextBox txtDifferentialTitle = (TextBox)grid.Children[13];
            Image imgRadBtnComplete = (Image)grid.Children[14];
            Image imgRadBtnDifferential = (Image)grid.Children[15];
            RadioButton radioBtnCompleteType = (RadioButton)grid.Children[16];
            RadioButton radioBtnDifferentialType = (RadioButton)grid.Children[17];
            TextBox txtSourcePathTitle = (TextBox)grid.Children[18];
            TextBox txtTargetPathTitle = (TextBox)grid.Children[19];
            TextBox txtSourcePathSelected = (TextBox)grid.Children[20];
            TextBox txtTargetPathSelected = (TextBox)grid.Children[21];
            Image imgSourceFolder = (Image)grid.Children[22];
            Image imgTargetFolder = (Image)grid.Children[23];
            Button btnSourceBrowse = (Button)grid.Children[24];
            Button btnTargetBrowse = (Button)grid.Children[25];

            progressBar.Visibility = Visibility.Visible;
            rButtonStop.Visibility = Visibility.Visible;
            rButtonPause.Visibility = Visibility.Visible;
            imgStopButton.Visibility = Visibility.Visible;
            imgChangeStateButton.Visibility = Visibility.Visible;

            imgStartButton.Visibility = Visibility.Hidden;
            imgDeleteButton.Visibility = Visibility.Hidden;
            btnSourceBrowse.Visibility = Visibility.Hidden;
            btnTargetBrowse.Visibility = Visibility.Hidden;
            rButtonStart.Visibility = Visibility.Hidden;
            rButtonDelete.Visibility = Visibility.Hidden;
            radioBtnCompleteType.Visibility = Visibility.Hidden;
            radioBtnDifferentialType.Visibility = Visibility.Hidden;
            txtCompleteTitle.Visibility = Visibility.Hidden;
            txtDifferentialTitle.Visibility = Visibility.Hidden;
            txtSourcePathTitle.Visibility = Visibility.Hidden;
            txtTargetPathTitle.Visibility = Visibility.Hidden;
            txtSourcePathSelected.Visibility = Visibility.Hidden;
            txtTargetPathSelected.Visibility = Visibility.Hidden;
            imgSourceFolder.Visibility = Visibility.Hidden;
            imgTargetFolder.Visibility = Visibility.Hidden;
            imgRadBtnComplete.Visibility = Visibility.Hidden;
            imgRadBtnDifferential.Visibility = Visibility.Hidden;

            imgChangeStateButton.Source = new BitmapImage(new Uri("\\Images\\PauseIcon.png", UriKind.Relative));
        }
        public void PausedBackup(string saveName)
        {
            Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;

            Button rButtonPause = (Button)grid.Children[8];
            Button rButtonPlay = (Button)grid.Children[9];
            Image imgChangeStateButton = (Image)grid.Children[6];

            rButtonPlay.Visibility = Visibility.Visible;
            rButtonPause.Visibility = Visibility.Hidden;

            imgChangeStateButton.Source = new BitmapImage(new Uri("\\Images\\PlayIcon.png", UriKind.Relative));
        }
        public void PlayedBackup(string saveName)
        {
            Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;

            Button rButtonPause = (Button)grid.Children[8];
            Button rButtonPlay = (Button)grid.Children[9];
            Image imgChangeStateButton = (Image)grid.Children[6];

            rButtonPlay.Visibility = Visibility.Hidden;
            rButtonPause.Visibility = Visibility.Visible;

            imgChangeStateButton.Source = new BitmapImage(new Uri("\\Images\\PauseIcon.png", UriKind.Relative));
        }
        public void StoppedBackup(string saveName)
        {
            Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;

            ProgressBar progressBar = (ProgressBar)grid.Children[1];
            Image imgStartButton = (Image)grid.Children[3];
            Image imgDeleteButton = (Image)grid.Children[4];
            Image imgStopButton = (Image)grid.Children[5];
            Image imgChangeStateButton = (Image)grid.Children[6];
            Button rButtonStop = (Button)grid.Children[7];
            Button rButtonPause = (Button)grid.Children[8];
            Button rButtonStart = (Button)grid.Children[10];
            Button rButtonDelete = (Button)grid.Children[11];
            TextBox txtCompleteTitle = (TextBox)grid.Children[12];
            TextBox txtDifferentialTitle = (TextBox)grid.Children[13];
            Image imgRadBtnComplete = (Image)grid.Children[14];
            Image imgRadBtnDifferential = (Image)grid.Children[15];
            RadioButton radioBtnCompleteType = (RadioButton)grid.Children[16];
            RadioButton radioBtnDifferentialType = (RadioButton)grid.Children[17];
            TextBox txtSourcePathTitle = (TextBox)grid.Children[18];
            TextBox txtTargetPathTitle = (TextBox)grid.Children[19];
            TextBox txtSourcePathSelected = (TextBox)grid.Children[20];
            TextBox txtTargetPathSelected = (TextBox)grid.Children[21];
            Image imgSourceFolder = (Image)grid.Children[22];
            Image imgTargetFolder = (Image)grid.Children[23];
            Button btnSourceBrowse = (Button)grid.Children[24];
            Button btnTargetBrowse = (Button)grid.Children[25];


            progressBar.Visibility = Visibility.Hidden;
            rButtonStop.Visibility = Visibility.Hidden;
            rButtonPause.Visibility = Visibility.Hidden;
            imgStopButton.Visibility = Visibility.Hidden;
            imgChangeStateButton.Visibility = Visibility.Hidden;

            imgStartButton.Visibility = Visibility.Visible;
            imgDeleteButton.Visibility = Visibility.Visible;
            btnSourceBrowse.Visibility = Visibility.Visible;
            btnTargetBrowse.Visibility = Visibility.Visible;
            rButtonStart.Visibility = Visibility.Visible;
            rButtonDelete.Visibility = Visibility.Visible;
            radioBtnCompleteType.Visibility = Visibility.Visible;
            radioBtnDifferentialType.Visibility = Visibility.Visible;
            txtCompleteTitle.Visibility = Visibility.Visible;
            txtDifferentialTitle.Visibility = Visibility.Visible;
            txtSourcePathTitle.Visibility = Visibility.Visible;
            txtTargetPathTitle.Visibility = Visibility.Visible;
            txtSourcePathSelected.Visibility = Visibility.Visible;
            txtTargetPathSelected.Visibility = Visibility.Visible;
            imgSourceFolder.Visibility = Visibility.Visible;
            imgTargetFolder.Visibility = Visibility.Visible;
            imgRadBtnComplete.Visibility = Visibility.Visible;
            imgRadBtnDifferential.Visibility = Visibility.Visible;
        }

        // Methods Calleds by View Events
        public void StartAllBackup(bool FromRemote)
        {
            if (!FromRemote)
            {
                Communication.SendingSemaphore.WaitOne();
                Communication.SendData("Start all backups");
                Communication.SendingSemaphore.Release();
            }
            
            foreach (var save in Saves)
                StartBackup(save.Name, FromRemote);
        }
        public void StartBackup(string saveName, bool FromRemote)
        {
            if (!FromRemote)
            {
                Communication.SendingSemaphore.WaitOne();
                Communication.SendData("Start_backup");
                Communication.SendData(saveName);
                Communication.SendingSemaphore.Release();
            }

            Application.Current.Dispatcher.Invoke(() => { ActiveBackUp(saveName); });
        }
        public void DeleteBackup(string saveName)
        {
            Communication.SendingSemaphore.WaitOne();
            Communication.SendData("Delete backup");
            Communication.SendData(saveName);
            Communication.SendingSemaphore.Release();

        }
        public void ChangeBackUpType(string saveName, string Type)
        {
            Communication.SendingSemaphore.WaitOne();
            Communication.SendData("Edit backup type");
            Communication.SendData(saveName + " " + Type); 
            Communication.SendingSemaphore.Release();
        }
        public void ChangePathSave(string saveName, string type, string path)
        {
            Communication.SendingSemaphore.WaitOne();
            Communication.SendData("Edit backup path");
            Communication.SendData(saveName + " " + type + " " + path);
            Communication.SendingSemaphore.Release();
        }
        public void DynamicSearch(string textSearch, StackPanel stackPanel)
        {
            if (stackPanel != null)
            {
                List<GroupItem> ToRemove = new List<GroupItem>();
                foreach (var child in stackPanel.Children)
                {
                    GroupItem groupitem = (GroupItem)child;
                    if (textSearch != null && !groupitem.Name.Contains(textSearch))
                        ToRemove.Add(groupitem);
                    else
                        groupitem.Visibility = System.Windows.Visibility.Visible;
                }
                foreach (var groupItem in ToRemove)
                {
                    stackPanel.Children.Remove(groupItem);
                }
            }
        }

        // BackUp threads managment methods
        public void ChangeState(string saveName, string Type, bool FromRemote)
        {
            if (!FromRemote)
            {
                Communication.SendingSemaphore.WaitOne();
                Communication.SendData("Change backup's state");
                Communication.SendData(saveName + " " + Type);
                Communication.SendingSemaphore.Release();
            }
            if (Type == "Pause")
                Application.Current.Dispatcher.Invoke(() => { PausedBackup(saveName); });
            if (Type == "Play")
                Application.Current.Dispatcher.Invoke(() => { PlayedBackup(saveName); });
        }
        public void StopBackUp(string saveName, bool FromRemote)
        {
            if (!FromRemote)
            {
                Communication.SendingSemaphore.WaitOne();
                Communication.SendData("Stop backup");
                Communication.SendData(saveName);
                Communication.SendingSemaphore.Release();
            }

        }

        public void UpdateProgressBar(string saveName, int value)
        {
            Application.Current.Dispatcher.Invoke(() => 
            {
                Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;
                var progressBar = (ProgressBar)grid.Children[1];
                progressBar.Value = value; 
            });
        }
        public bool IsCompleteType(Save save)
        {
            if (save.Type == "Complete")
                return true;
            else
                return false;
        }
        public BitmapImage GetActualRadioButton(RadioButton btn)
        {
            if (btn.IsChecked.Value)
                return new BitmapImage(new Uri("\\Images\\RadioButtonChecked.png", UriKind.Relative));
            else
                return new BitmapImage(new Uri("\\Images\\RadioButtonUnchecked.png", UriKind.Relative));
        }
        public void FolderDialog(Button sender, string saveName)
        {
            TextBox targetTextBox = GetPathTextBox(saveName, "Target");
            TextBox sourceTextBox = GetPathTextBox(saveName, "Source");
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string path = dialog.SelectedPath;

                    if (sender.Name.Substring(0, sender.Name.IndexOf('_')) == "SelectTargetButton")
                    {
                        targetTextBox.Text = path;
                        ChangePathSave(saveName, "Target", path);
                    }
                    else if (sender.Name.Substring(0, sender.Name.IndexOf('_')) == "SelectSourceButton")
                    {
                        sourceTextBox.Text = path;
                        ChangePathSave(saveName, "Source", path);
                    }
                }
            }
        }
        private TextBox GetPathTextBox(string saveName, string type)
        {
            Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;

            TextBox target = (TextBox)grid.Children[21];
            TextBox source = (TextBox)grid.Children[20];

            if (type == "Target")
                return target;
            else
                return source;
        }
    }
}
