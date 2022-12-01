using System;
using System.Collections.Generic;
using System.Text;
using EasySaveApp.View;
using EasySaveApp.Model;
using System.Threading;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EasySaveApp.Networking;

namespace EasySaveApp.ViewModel
{
    public class BackUpViewModel
    {
        private Settings Settings;
        private List<Save> Saves;
        private static List<string> UsedSourcePath = new List<string>();
        public static StackPanel BackupList { get; set; }

        public List<Save> GetSaveList() { return Saves; }
        private static BackUpViewModel Instance { get; set; }
        public static BackUpViewModel GetBackUpViewModel()
        {
            if (Instance == null)
                Instance = new BackUpViewModel();
            return Instance;
        }
        private BackUpViewModel()
        {
            Saves = MainViewModel.GetMainViewModel().saves;
            Settings = Settings.GetSettings();
        }

        // VIew Modifications
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
            VerVerifySameSourcePathStart(2, saveName);
        }

        // Methods Calleds by View Events
        public void StartAllBackup(bool FromRemote)
        {
            if (!FromRemote)
            {
                Communication.sendSemaphore.WaitOne();
                Communication.SendData("Start all backups");
                Communication.sendSemaphore.Release();
            }
            foreach (Save save in Saves)
                StartBackup(save.Name, FromRemote);
                
        }
        public void StartBackup(string saveName, bool FromRemote)
        {
            foreach (var save in Saves)
            {
                if (save.Name == saveName)
                {
                    if (!FromRemote)
                    {
                        Communication.sendSemaphore.WaitOne();
                        Communication.SendData("Start_backup");
                        Communication.SendData(saveName);
                        Communication.sendSemaphore.Release();
                    }
                    Application.Current.Dispatcher.Invoke(() => { ActiveBackUp(save.Name); });
                    new Thread(() => { save.StartSave(Settings.xmlLogs); }).Start();
                    break;
                }
            }
        }
        public void DeleteBackup(string saveName, bool fromRemote)
        {
            if (UserErrorManagement.ChoicePopUp(Properties.Langs.Lang.VBU_Delete) || fromRemote)
            {
                foreach (var save in Saves)
                {
                    if (save.Name == saveName)
                    {
                        Saves.Remove(save);
                        break;
                    }
                }
                Application.Current.Dispatcher.Invoke(() => { BackupList.Children.Remove(GetCurrentSaveGrid(saveName)); });
                BackupManagment.GetBackupManagment().SaveBackupList(MainViewModel.GetMainViewModel());
            }
        }
        public void ChangePathSave(string saveName, string type, string path)
        {
            foreach (var save in Saves)
            {
                if (save.Name == saveName)
                {
                    if (type == "Target")
                        save.Target = path;
                    else if (type == "Source")
                        save.Source = path;
                    BackupManagment.GetBackupManagment().SaveBackupList(MainViewModel.GetMainViewModel());
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BackupList.Visibility = Visibility.Hidden;
                        BackupList.Visibility = Visibility.Visible;
                    });
                    break;
                }
            }
        }
        public void ChangeBackUpType(string saveName, string Type)
        {
            foreach (var save in Saves)
            {
                if (save.Name == saveName)
                {
                    save.Type = Type;
                    BackupManagment.GetBackupManagment().SaveBackupList(MainViewModel.GetMainViewModel());
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BackupList.Visibility = Visibility.Hidden;
                        BackupList.Visibility = Visibility.Visible;
                    });
                    break;
                }
            }
        }

        // BackUp threads managment methods
        public void ChangeState(string saveName, string Type, bool FromRemote)
        {
            foreach (var save in Saves)
            {
                if (save.Name == saveName)
                {
                    save.IsStatePlay = !save.IsStatePlay;
                    if (!FromRemote)
                    {
                        Communication.sendSemaphore.WaitOne();
                        Communication.SendData("Change backup's state");
                        Communication.SendData(saveName + " " + Type);
                        Communication.sendSemaphore.Release();
                    }
                    if (Type == "Pause")
                        Application.Current.Dispatcher.Invoke(() => { PausedBackup(saveName); });
                    if (Type == "Play")
                        Application.Current.Dispatcher.Invoke(() => { PlayedBackup(saveName); });
                    break;
                }
            }
        }
        public void StopBackUp(string saveName)
        {
            foreach (var save in Saves)
            {
                if (save.Name == saveName)
                {
                    save.Cancel = true;
                    Communication.sendSemaphore.WaitOne();
                    Communication.SendData("Stop backup");
                    Communication.SendData(saveName);
                    Communication.sendSemaphore.Release();
                    break;
                }
            }
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

        public void UpdateProgressBar(string saveName, int value)
        {
            Application.Current.Dispatcher.Invoke(()=> 
            { 
                Grid grid = (Grid)GetCurrentSaveGrid(saveName).Content;
                var progressBar = (ProgressBar)grid.Children[1];
                progressBar.Value = value;

                Communication.sendSemaphore.WaitOne();
                Communication.SendData("Get progress");
                Communication.SendData(saveName + " " + value.ToString());
                Communication.sendSemaphore.Release();
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

                    if (sender.Name.Substring(0, sender.Name.IndexOf('_')) == "SelectTargetButton"&& VerifyPath(sourceTextBox.Text, path))
                    {
                        targetTextBox.Text = path;
                        ChangePathSave(saveName, "Target", path);
                    }
                    else if (sender.Name.Substring(0, sender.Name.IndexOf('_')) == "SelectSourceButton" && VerifyPath(path, targetTextBox.Text))
                    {
                        sourceTextBox.Text = path;
                        ChangePathSave(saveName, "Source", path);
                    }
                }
            }
        }
        public void RefreshListSave()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                BackupList.Visibility = Visibility.Hidden;
                BackupList.Visibility = Visibility.Visible;
            });
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
        public static bool VerVerifySameSourcePathStart(int state, string saveName = "") //Check depending to the state, a certain parameter about the save entered
        {
            List<Save>savesList = MainViewModel.GetMainViewModel().saves; // get the save list

            if (state == 0) // check if a save is running
            {
                if(UsedSourcePath.Count == 0) // if 0 → no save running
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (state == 1) // check if sourcepath is into the running UsedSourcePath list, add it if not
            {
                foreach (var save in savesList) //parse the savelist
                {
                    if (save.Name == saveName)  //check if the savename match with the entry
                    {
                        if (UsedSourcePath.Contains(save.Source)) //if is in, do not add it
                        {
                            return false;
                        }
                        else
                        {
                            UsedSourcePath.Add(save.Source); //if is not in, add it
                            return true;
                        }
                    }
                }
                    
            }

            else if (state == 2) // remove source path from UsedSourcePath list
            {
                foreach (var save in savesList) // parse the savelist
                {
                    if (save.Name == saveName)  //check if the savename match with the entry
                    {
                        UsedSourcePath.Remove(save.Source); //remove from UsedSourcePath list
                        return true;
                    }
                    else
                    {
                       //do nothing
                    }
                }

                return false; //An error has occured
            }

            else
                return false; //should not happen

            return true;
        }

        public bool VerifyPath(string Source, string Target)
        {
            if (Input.VerifyPath(Target, 1) && Input.VerifyPath(Source, 0) && Input.NotSamePath(Source, Target))
                return true;

            else if (!Input.VerifyPath(Source, 0) && !Input.VerifyPath(Target, 1))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_NoPath);
                return false;
            }
            else if (!Input.VerifyPath(Source, 0))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_NoSource);
                return false;
            }
            else if (!Input.VerifyPath(Target, 1))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_NoTarget);
                return false;
            }
            else if (!Input.NotSamePath(Source, Target))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_SamePath);
                return false;
            }
            else
                return false;
        }
    }
}
