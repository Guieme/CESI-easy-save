using EasySaveApp_Client.Model;
using EasySaveApp_Client.Networking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EasySaveApp_Client.ViewModel
{
    class CreateBackUpViewModel
    {
        private static CreateBackUpViewModel Instance;
        public static CreateBackUpViewModel GetCreateBackUpViewModel()
        {
            if (Instance == null)
                Instance = new CreateBackUpViewModel();
            return Instance;
        }

        private CreateBackUpViewModel() { }
        public bool ConfirmSave(RadioButton complete, RadioButton differential, TextBox target, TextBox source, TextBox name)
        {
            string type;
            if (complete.IsChecked.Value)
                type = "Complete";
            else if (differential.IsChecked.Value)
                type = "Differential";
            else
                type = "Complete";
            name.Text = name.Text.Replace(" ", "_");

            if (!AddBackup(name.Text, source.Text, target.Text, type))
                return false;
            return true;
        }
        public bool AddBackup(string Name, string Source, string Target, string Type)
        {
            if (Input.VerifyPath(Target, 1) && Input.VerifyPath(Source, 0) && Input.VerifySave(Name) && Input.NotSamePath(Source, Target))
            {
                Communication.SendingSemaphore.WaitOne();
                Communication.SendData("Add backup");
                Communication.SendData(Name + " " + Source + " " + Target + " " + Type);
                Communication.SendingSemaphore.Release();
                return true;
            }
            else if (!Input.VerifySave(Name))
            {
                UserErrorManagement.ErrorPopUp(Properties.Langs.Lang.Error_SameSaveName);
                return false;
            }
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
            {
                return false;
            }
        }
        //public void AddBackup(string name, string source, string target, string type)
        //{
        //    Communication.SendData("Add backup");
        //    Communication.SendData(name + " " + source + " " + target + " " + type);
        //}

        public void FolderDialog(RadioButton sender, TextBox source, TextBox target)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (sender.Name == "SelectTargetButton")
                        target.Text = dialog.SelectedPath;
                    if (sender.Name == "SelectSourceButton")
                        source.Text = dialog.SelectedPath;
                }
            }
        }
        public void CheckedMode(Image complete, Image differential, RadioButton source)
        {
            if (source.Name == "DifférentialRadioButton")
            {
                differential.Source = new BitmapImage(new Uri(@"\Images\FrameWrokPlain.png", UriKind.Relative));
                complete.Source = new BitmapImage(new Uri("\\Images\\FrameWrok.png", UriKind.Relative));
            }
            else if (source.Name == "CompleteRadioButton")
            {
                differential.Source = new BitmapImage(new Uri("\\Images\\FrameWrok.png", UriKind.Relative));
                complete.Source = new BitmapImage(new Uri(@"\Images\FrameWrokPlain.png", UriKind.Relative));
            }
        }
    }
}
